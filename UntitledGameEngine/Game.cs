using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using UntitledGameEngine.Core;
using UntitledGameEngine.Physics;
using UntitledGameEngine.Rendering;

namespace UntitledGameEngine
{
    public class Game : GameWindow
    {
        private RenderSystem renderSystem = new RenderSystem();
        private CollisionSystem collisionSystem = new CollisionSystem();

        private Scene mainScene = new Scene("MainScene");

        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings()
        {
            ClientSize = (width, height),
            Title = title
        })
        { }

        protected override void OnLoad()
        {
            base.OnLoad();

            renderSystem.Initialize();

            mainScene.Start();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            Input.Update(KeyboardState);

            collisionSystem.Update();

            mainScene.Update((float)args.Time);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            mainScene.Render(renderSystem);

            SwapBuffers();
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            renderSystem.Dispose();
        }
    }
}
