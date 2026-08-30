using OpenTK.Graphics.OpenGL4;
using System.Drawing;
using OpenTK.Mathematics;

namespace Pong
{
    internal class RenderSystem : IDisposable
    {
        Shader shader;
        int modelLocation;
        int projectionLocation;
        int colorLocation;

        Matrix4 projection;

        Mesh square = PrimitiveMesh.CreateSquare();
        Mesh circle = PrimitiveMesh.CreateCircle(32);

        public void Initialize()
        {
            shader = new Shader("Resources/Shaders/shader.vert", "Resources/Shaders/shader.frag");

            modelLocation = GL.GetUniformLocation(shader.Handle, "ModelMatrix");
            projectionLocation = GL.GetUniformLocation(shader.Handle, "ProjectionMatrix");
            colorLocation = GL.GetUniformLocation(shader.Handle, "Color");

            square.Initialize();
            circle.Initialize();
        }

        public void DrawSquare(Vector2 position, Vector2 scale, Color color)
        {
            Matrix4 model = Matrix4.CreateScale(scale.X, scale.Y, 1) * Matrix4.CreateTranslation(position.X, position.Y, 0);

            shader.Use();

            GL.UniformMatrix4(modelLocation, false, ref model);
            GL.UniformMatrix4(projectionLocation, false, ref projection);

            GL.Uniform4(colorLocation, color);

            square.Draw();
        }

        public void DrawCircle(Vector2 position, Vector2 scale, Color color)
        {
            Matrix4 model = Matrix4.CreateScale(scale.X, scale.Y, 1) * Matrix4.CreateTranslation(position.X, position.Y, 0);

            shader.Use();

            GL.UniformMatrix4(modelLocation, false, ref model);
            GL.UniformMatrix4(projectionLocation, false, ref projection);

            GL.Uniform4(colorLocation, color);

            circle.Draw();
        }

        public void Dispose()
        {
            shader.Dispose();

            square.Dispose();
            circle.Dispose();
        }

        public void SetViewportSize(int width, int height)
        {
            projection = Matrix4.CreateOrthographicOffCenter(0, width, height, 0, -1, 1);
        }
    }
}
