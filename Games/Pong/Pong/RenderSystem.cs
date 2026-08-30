using OpenTK.Graphics.OpenGL4;
using System.Drawing;
using OpenTK.Mathematics;

namespace Pong
{
    internal class RenderSystem : IDisposable
    {
        Mesh mesh;

        Shader shader;
        int modelLocation;
        int projectionLocation;
        int colorLocation;

        Matrix4 projection;

        public void Initialize()
        {
            shader = new Shader("Resources/Shaders/shader.vert", "Resources/Shaders/shader.frag");

            modelLocation = GL.GetUniformLocation(shader.Handle, "ModelMatrix");
            projectionLocation = GL.GetUniformLocation(shader.Handle, "ProjectionMatrix");
            colorLocation = GL.GetUniformLocation(shader.Handle, "Color");
        }

        public void DrawSquare(Vector2 position, Vector2 scale, Color color)
        {
            Matrix4 model = Matrix4.CreateScale(scale.X, scale.Y, 1) * Matrix4.CreateTranslation(position.X, position.Y, 0);

            shader.Use();

            GL.UniformMatrix4(modelLocation, false, ref model);
            GL.UniformMatrix4(projectionLocation, false, ref projection);

            GL.Uniform4(colorLocation, color);
        }

        public void Dispose()
        {
            shader.Dispose();
        }

        public void SetViewportSize(int width, int height)
        {
            projection = Matrix4.CreateOrthographicOffCenter(0, width, height, 0, -1, 1);
        }
    }
}
