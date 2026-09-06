using OpenTK.Graphics.OpenGL4;
using Matrix4 = OpenTK.Mathematics.Matrix4;
using System.Drawing;
using System.Numerics;

namespace UntitledGameEngine.Rendering
{
    public class RenderSystem : IDisposable
    {
        Shader shader;
        int modelLocation;
        int projectionLocation;
        int colorLocation;

        Matrix4x4 projection;

        Mesh square = PrimitiveMesh.CreateSquare();
        Mesh circle = PrimitiveMesh.CreateCircle(32);

        public Color backgroundColor = Color.Black;

        public void Initialize()
        {
            string vertexPath = Path.Combine("Resources", "Shaders", "shader.vert");
            string fragmentPath = Path.Combine("Resources", "Shaders", "shader.frag");

            shader = new Shader(vertexPath, fragmentPath);

            GL.ClearColor(backgroundColor);

            modelLocation = GL.GetUniformLocation(shader.Handle, "ModelMatrix");
            projectionLocation = GL.GetUniformLocation(shader.Handle, "ProjectionMatrix");
            colorLocation = GL.GetUniformLocation(shader.Handle, "Color");

            square.Initialize();
            circle.Initialize();
        }

        public void DrawSquare(Vector2 position, Vector2 scale, Color color)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Matrix4x4 model = Matrix4x4.CreateScale(scale.X, scale.Y, 1) * Matrix4x4.CreateTranslation(position.X, position.Y, 0);

            shader.Use();

            Matrix4 openTkModel = OpenTKConversions.ConvertMatrix(model);
            Matrix4 openTkProjection = OpenTKConversions.ConvertMatrix(projection);

            GL.UniformMatrix4(modelLocation, false, ref openTkModel);
            GL.UniformMatrix4(projectionLocation, false, ref openTkProjection);

            GL.Uniform4(colorLocation, color);

            square.Draw();
        }

        public void DrawCircle(Vector2 position, Vector2 scale, Color color)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Matrix4x4 model = Matrix4x4.CreateScale(scale.X, scale.Y, 1) * Matrix4x4.CreateTranslation(position.X, position.Y, 0);

            shader.Use();

            Matrix4 openTkModel = OpenTKConversions.ConvertMatrix(model);
            Matrix4 openTkProjection = OpenTKConversions.ConvertMatrix(projection);

            GL.UniformMatrix4(modelLocation, false, ref openTkModel);
            GL.UniformMatrix4(projectionLocation, false, ref openTkProjection);

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
            projection = Matrix4x4.CreateOrthographicOffCenter(0, width, height, 0, -1, 1);
        }
    }
}
