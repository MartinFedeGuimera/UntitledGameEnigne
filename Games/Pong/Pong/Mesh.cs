using OpenTK.Graphics.OpenGL4;

namespace Pong
{
    internal class Mesh
    {
        private int VertexArrayObject {  get; set; }

        private int VertexBufferObject { get; set; }

        private int ElementBufferObject { get; set; }

        private float[] vertexs;

        private uint[] indexes;

        public Mesh(float[] vertexs, uint[] indexes)
        {
            this.vertexs = vertexs;
            this.indexes = indexes;
        }

        public void Initialize()
        {
            VertexArrayObject = GL.GenVertexArray();
            VertexBufferObject = GL.GenBuffer();
            ElementBufferObject = GL.GenBuffer();

            GL.BindVertexArray(VertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indexes.Length * sizeof(uint), indexes, BufferUsageHint.StaticDraw);

            GL.BufferData(BufferTarget.ArrayBuffer, vertexs.Length * sizeof(float), vertexs, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Draw()
        {
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, indexes.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(VertexArrayObject);
            GL.DeleteBuffer(VertexBufferObject);
            GL.DeleteBuffer(ElementBufferObject);
        }
    }
}
