using OpenTK.Mathematics;

namespace Pong
{
    internal static class PrimitiveMesh
    {
        public static Mesh CreateSquare()
        {
            float[] vertices = {
                -0.5f,  0.5f,
                 0.5f,  0.5f,
                 -0.5f, -0.5f,
                 0.5f, -0.5f
                };

            uint[] indices = {
                0, 1, 2,
                1, 2, 3
                };

            return new Mesh(vertices, indices);
        }

        public static Mesh CreateCircle(int segments)
        {
            float[] vertices = new float[(segments + 1) * 2];

            float radius = 0.5f;

            vertices[0] = 0.0f;
            vertices[1] = 0.0f;

            for (int i = 0; i < segments; i++)
            {
                float angle = (360.0f / segments) * i;
                float radians = MathHelper.DegreesToRadians(angle);

                vertices[i * 2 + 2] = MathF.Cos(radians) * radius;
                vertices[i * 2 + 3] = MathF.Sin(radians) * radius;
            }

            uint[] indices = new uint[segments * 3];

            for (int i = 0; i < segments; i++)
            {
                indices[i * 3] = 0;
                indices[i * 3 + 1] = (uint)i + 1;
                indices[i * 3 + 2] = (uint)((i + 1) % segments) + 1;
            }

            return new Mesh(vertices, indices);
        }
    }
}
