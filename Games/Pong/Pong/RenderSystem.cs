using OpenTK.Graphics.OpenGL4;
using System.Drawing;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Pong
{
    internal class RenderSystem : IDisposable
    {
        private int VertexArrayObject;

        private int VertexBufferObject;

        private int ElementBufferObject;

        Shader shader;
        int modelLocation;
        int projectionLocation;
        int colorLocation;

        Matrix4 projection;

        public void Initialize()
        {
            VertexArrayObject = GL.GenVertexArray();
            VertexBufferObject = GL.GenBuffer();
            ElementBufferObject = GL.GenBuffer();

            shader = new Shader("Resources/Shaders/shader.vert", "Resources/Shaders/shader.frag");

            modelLocation = GL.GetUniformLocation(shader.Handle, "ModelMatrix");
            projectionLocation = GL.GetUniformLocation(shader.Handle, "ProjectionMatrix");
            colorLocation = GL.GetUniformLocation(shader.Handle, "Color");
        }

        public void DrawSquare(Vector2 position, Vector2 scale, Color color)
        {
            Matrix4 model = Matrix4.CreateScale(scale.X, scale.Y, 1) * Matrix4.CreateTranslation(position.X, position.Y, 0);

            float[] vertexs = {
                 0.5f,  0.5f, 0.0f,  // top right
                 0.5f, -0.5f, 0.0f,  // bottom right
                -0.5f, -0.5f, 0.0f,  // bottom left
                -0.5f,  0.5f, 0.0f   // top left
            };

            uint[] indexes = {
                0, 1, 3,   // first triangle
                1, 2, 3    // second triangle
            };

            GL.BindVertexArray(VertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indexes.Length * sizeof(uint), indexes, BufferUsageHint.StaticDraw);

            GL.BufferData(BufferTarget.ArrayBuffer, vertexs.Length * sizeof(float), vertexs, BufferUsageHint.StaticDraw);

            shader.Use();

            GL.UniformMatrix4(modelLocation, false, ref model);
            GL.UniformMatrix4(projectionLocation, false, ref projection);

            GL.Uniform4(colorLocation, color);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.BindVertexArray(VertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, indexes.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(VertexArrayObject);
            GL.DeleteBuffer(VertexBufferObject);
            GL.DeleteBuffer(ElementBufferObject);

            shader.Dispose();
        }

        public void SetViewportSize(int width, int height)
        {
            projection = Matrix4.CreateOrthographicOffCenter(0, width, height, 0, -1, 1);
        }
    }
}
