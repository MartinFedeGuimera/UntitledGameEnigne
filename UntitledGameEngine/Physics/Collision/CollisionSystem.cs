using System.Numerics;

namespace UntitledGameEngine.Physics
{
    public class CollisionSystem
    {
        private List<Collider> colliders = new List<Collider>();

        public void AddCollider(Collider collider)
        {
            colliders.Add(collider);
        }

        public void Update()
        {
            CheckColliders();
        }

        private void CheckColliders()
        {
            if (colliders.Count <= 0)
                return;

            for (int i = 0; i < colliders.Count; i++)
            {
                Collider a = colliders[i];

                for (int j = i + 1; j < colliders.Count; j++)
                {
                    Collider b = colliders[j];

                    Collision collision = DetectCollision(a, b);

                    if(collision != null)
                    {
                        a.GameObject.GetComponent<PhysicBody>().OnCollide(collision);
                        b.GameObject.GetComponent<PhysicBody>().OnCollide(collision);
                    }
                }
            }
        }

        private Collision DetectCollision(Collider a, Collider b)
        {
            Vector2[] normals = CalculateNormals(a, b);

            (float min, float max) aProjection = (0, 0);
            (float min, float max) bProjection = (0, 0);

            float penetration = 0.0f;
            float overlap;

            Vector2 collisionNormal = Vector2.Zero;

            foreach (var normal in normals)
            {
                aProjection = Proyect(a.GetVertices(), normal);
                bProjection = Proyect(b.GetVertices(), normal);

                if (aProjection.min > bProjection.max || bProjection.min > aProjection.max)
                    return null;

                overlap = MathF.Min(aProjection.max, bProjection.max) - MathF.Max(aProjection.min, bProjection.min);

                if(overlap < penetration)
                {
                    penetration = overlap;
                    collisionNormal = normal;
                }
            }

            Collision collision = new Collision(a, b, collisionNormal, penetration);

            return collision;
        }

        private Vector2[] CalculateNormals(Collider a, Collider b)
        {
            Vector2[] normals = new Vector2[a.GetNormals().Length + b.GetNormals().Length];

            for (int k = 0; k < a.GetNormals().Length; k++)
            {
                normals[k] = a.GetNormals()[k];
            }
            for (int k = 0; k < b.GetNormals().Length; k++)
            {
                normals[k + a.GetNormals().Length] = b.GetNormals()[k];
            }

            return normals;
        }

        private (float min, float max) Proyect(Vector2[] vertices, Vector2 normal)
        {
            float[] projections = new float[vertices.Length];

            for(int i = 0; i < vertices.Length; i++)
            {
                var projection = Vector2.Dot(vertices[i], normal);
                projections[i] = projection;
            }

            return (projections.Min(), projections.Max());
        }
    }
}
