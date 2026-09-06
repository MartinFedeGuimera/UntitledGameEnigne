using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using UntitledGameEngine.Core;

namespace UntitledGameEngine
{
    internal class EngineWindow : GameWindow
    {
        private Game game;

        float fixedDeltaTime = 1.0f / 60.0f;
        float accumulator = 0.0f;

        public EngineWindow(Game game, GameSettings settings) : base(GameWindowSettings.Default, new NativeWindowSettings(){
            ClientSize = new Vector2i(settings.Width, settings.Height),
            Title = settings.Title
        })
        {
            this.game = game;
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            game.Start();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            float deltaTime = (float)args.Time;

            accumulator += deltaTime;

            while (accumulator >= fixedDeltaTime)
            {
                game.FixedUpdate(fixedDeltaTime);

                accumulator -= fixedDeltaTime;
            }

            Input.Update(KeyboardState);

            game.Update(deltaTime);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            
            game.Render();

            SwapBuffers();
        }

        protected override void OnUnload()
        {
            game.UnLoad();
        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);
            
            game.OnFramebufferResize(e.Width, e.Height);
        }
    }
}
