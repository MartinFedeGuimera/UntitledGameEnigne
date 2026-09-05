using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Pong.Collision;
using Pong.Objects;
using Pong.Objects.GameObject;
using Pong.Render;
using System.Drawing;

namespace Pong
{
    public class Game : GameWindow
    {
        RenderSystem render = new RenderSystem();
        CollisionSystem collider = new CollisionSystem();

        Scene scene = new Scene();

        GameObject leftPaddle = new GameObject("LeftPaddle");
        GameObject rightPaddle = new GameObject("RightPaddle");
        GameObject ball = new GameObject("Ball");

        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() 
            { 
                ClientSize = (width, height),
                Title = title 
            }) 
        { }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(Color.Black);

            render.Initialize();
            render.SetViewportSize(Size.X, Size.Y);

            scene.AddGameObject(leftPaddle);

            leftPaddle.AddComponent<Renderer>().shape = Shape.Square;
            leftPaddle.GetComponent<Renderer>().color = Color.Blue;

            collider.AddCollider(leftPaddle.AddComponent<Collider>());
            leftPaddle.GetComponent<Collider>().shape = CollisionShape.Square;

            leftPaddle.Transform.Position = new Vector2(100, 300);
            leftPaddle.Transform.Scale = new Vector2(50, 100);

            scene.AddGameObject(rightPaddle);

            rightPaddle.AddComponent<Renderer>().shape = Shape.Square;
            rightPaddle.GetComponent<Renderer>().color = Color.Red;

            collider.AddCollider(rightPaddle.AddComponent<Collider>());
            rightPaddle.GetComponent<Collider>().shape = CollisionShape.Square;

            rightPaddle.Transform.Position = new Vector2(75, 300);
            rightPaddle.Transform.Scale = new Vector2(50, 100);

            scene.AddGameObject(ball);

            ball.AddComponent<Renderer>().shape = Shape.Circle;
            ball.Transform.Position = new Vector2(400, 300);
            ball.Transform.Scale = new Vector2(20, 20);

            scene.Start();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            Input.Update(KeyboardState);
            collider.Update();

            scene.Update((float)args.Time);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            scene.Render(render);

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
