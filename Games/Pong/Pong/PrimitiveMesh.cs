namespace Pong
{
    internal static class PrimitiveMesh
    {
        public static Mesh CreateSquare()
        {
            float[] vertices = new float[]
            {
                -0.5f, 0.5f, 0.0f,
                0.5f, 0.5f, 0.0f,
                -0.5f, -0.5f, 0.0f,
                0.5f, -0.5f, 0.0f
            };

            uint[] indices = new uint[]
            {
                0, 1, 2,
                1, 2, 3
            };

            return new Mesh(vertices, indices);
        }
    }
}
