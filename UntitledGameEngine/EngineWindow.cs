using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using UntitledGameEngine.Core;

namespace UntitledGameEngine
{
    internal class EngineWindow : GameWindow
    {
        private Game game;

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

            Input.Update(KeyboardState);

            game.Update((float)args.Time);
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
    }
}
