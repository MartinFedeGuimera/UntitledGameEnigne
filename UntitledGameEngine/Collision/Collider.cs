using OpenTK.Mathematics;
using UntitledGameEngine.Objects.GameObject;

public enum CollisionShape
{
    None,
    Square
}

namespace UntitledGameEngine.Collision
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
                        (-0.5f,  0.5f),
                        (0.5f,  0.5f),
                        (0.5f, -0.5f),
                        (-0.5f, -0.5f)
                    };
                    break;
            }

            GetVertices();
            GetSides();
            GetNormals();
        }

        public Vector2[] GetVertices()
        {
            for(int i = 0; i < vertices.Length; i++)
            {
                Vector2 vertex = vertices[i] * GameObject.Transform.Scale;
                vertex += GameObject.Transform.Position;

                vertices[i] = vertex;
            }

            return vertices;
        }

        public Vector2[] GetSides()
        {
            int vertexCount = vertices.Length;

            sides = new Vector2[vertexCount];

            for(int i = 0; i < vertexCount; i++)
            {
                Vector2 currentVertex;
                Vector2 nextVertex;

                if(i != vertexCount - 1)
                {
                    currentVertex = vertices[i];
                    nextVertex = vertices[i + 1];
                }
                else
                {
                    currentVertex = vertices[i];
                    nextVertex = vertices[0];
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
                normals[i] = new Vector2(-sides[i].Y, sides[i].X);
            }

            return normals;
        }
    }
}
