using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;

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

            GL.ClearColor(Color.Blue);

            render.Initialize();
            render.SetViewportSize(Size.X, Size.Y);
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

            render.DrawSquare(new Vector2(400, 300), new Vector2(800, 300) ,Color.Yellow);

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

            render.SetViewportSize(e.Width, e.Height);
        }
    }
}
