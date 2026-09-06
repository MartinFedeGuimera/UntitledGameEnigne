using System.Numerics;
using UntitledGameEngine.Core;

public enum CollisionShape
{
    None,
    Square,
    Circle
}

namespace UntitledGameEngine.Physics
{
    public class Collider : Component
    {
        private Vector2[] vertices;
        public CollisionShape shape = CollisionShape.None;

        Vector2[] sides;
        Vector2[] normals;

        public override void Start()
        {
            switch(shape)
            {
                case CollisionShape.Square:
                    vertices = new Vector2[] {
                        new Vector2(-0.5f,  0.5f),
                        new Vector2(0.5f,  0.5f),
                        new Vector2(0.5f, -0.5f),
                        new Vector2(-0.5f, -0.5f)
                    };
                    break;
                case CollisionShape.None:
                    return;
            }

            GetVertices();
            GetSides();
            GetNormals();
        }

        public Vector2[] GetVertices()
        {
            Vector2[] worldVertices = new Vector2[vertices.Length];

            for(int i = 0; i < vertices.Length; i++)
            {
                Vector2 vertex = vertices[i] * GameObject.Transform.Scale;
                vertex += GameObject.Transform.Position;

                worldVertices[i] = vertex;
            }

            return worldVertices;
        }

        public Vector2[] GetSides()
        {
            Vector2[] worldVertices = GetVertices();
            int vertexCount = worldVertices.Length;

            sides = new Vector2[vertexCount];

            for(int i = 0; i < vertexCount; i++)
            {
                Vector2 currentVertex;
                Vector2 nextVertex;

                if(i != vertexCount - 1)
                {
                    currentVertex = worldVertices[i];
                    nextVertex = worldVertices[i + 1];
                }
                else
                {
                    currentVertex = worldVertices[i];
                    nextVertex = worldVertices[0];
                }

                sides[i] = new Vector2(nextVertex.X - currentVertex.X, nextVertex.Y - currentVertex.Y);
            }

            return sides;
        }

        public Vector2[] GetNormals()
        {
            normals = new Vector2[sides.Length];

            for(int i = 0; i < normals.Length; i++)
            {
                normals[i] = Vector2.Normalize(new Vector2(-sides[i].Y, sides[i].X));
            }

            return normals;
        }
    }
}
