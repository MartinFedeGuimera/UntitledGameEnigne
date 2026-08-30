using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;
using System.Resources;

namespace Pong
{
    public class Game : GameWindow
    {
        RenderSystem render = new RenderSystem();

        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() 
            { 
                ClientSize = (width, height),
                Title = title 
            }) 
        { }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(Color.Red);

            render.Initialize();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            Input.Update(KeyboardState);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            render.DrawSquare();

            SwapBuffers();
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            render.Dispose();
        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}
