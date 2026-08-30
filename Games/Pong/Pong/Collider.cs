using OpenTK.Mathematics;

namespace Pong
{
    internal class Collider : Component
    {
        private float[] vertices;

        Vector2[] sides;
        Vector2[] normals;

        public Vector2[] GetSides()
        {
            int vertexCount = vertices.Length / 2;

            sides = new Vector2[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                int next = (i + 1) % vertexCount;

                Vector2 current = new Vector2(
                    vertices[i * 2],
                    vertices[i * 2 + 1]
                );

                Vector2 nextVertex = new Vector2(
                    vertices[next * 2],
                    vertices[next * 2 + 1]
                );

                sides[i] = nextVertex - current;
            }

            return sides;
        }

        public Vector2[] GetNormals()
        {
            int vertexCount = vertices.Length / 2;

            normals = new Vector2[vertexCount];

            for (int i = 0; i < sides.Length; i++)
            {
                normals[i] = new Vector2(-sides[i].Y, sides[i].X).Normalized();
            }

            return normals;
        }
    }
}
