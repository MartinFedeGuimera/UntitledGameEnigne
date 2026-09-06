using System.Numerics;
using UntitledGameEngine.Core;

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
            CheckCollisions();
        }

        private void CheckCollisions()
        {
            if (colliders.Count <= 0)
                return;

            for (int i = 0; i < colliders.Count; i++)
            {
                Collider a = colliders[i];

                for (int j = i + 1; j < colliders.Count; j++)
                {
                    Collider b = colliders[j];

                    Collision collision = new Collision(a, b, Vector2.Zero, 0.0f);

                    if(a.shape == CollisionShape.Circle && b.shape == CollisionShape.Square)
                    {
                        collision = DetectCircleConvexCollision(a, b);
                    }
                    else if(a.shape == CollisionShape.Circle && b.shape == CollisionShape.Circle)
                    {
                        collision = DetectCircleCollision(a, b);
                    }
                    else
                    {
                        collision = DetectConvexCollision(a, b);
                    }

                    if (collision != null)
                    {
                        a.GameObject.GetComponent<PhysicBody>().OnCollide(collision);
                        b.GameObject.GetComponent<PhysicBody>().OnCollide(collision);
                    }
                }
            }
        }

        private Collision DetectConvexCollision(Collider a, Collider b)
        {
            Vector2[] normals = CalculateNormals(a, b);

            (float min, float max) aProjection = (0, 0);
            (float min, float max) bProjection = (0, 0);

            float penetration = float.MaxValue;
            float overlap;

            Vector2 collisionNormal = Vector2.Zero;

            foreach (var normal in normals)
            {
                aProjection = Proyect(a.GetVertices(), normal);
                bProjection = Proyect(b.GetVertices(), normal);

                if (aProjection.min > bProjection.max || bProjection.min > aProjection.max)
                {
                    return null;
                }

                overlap = MathF.Min(aProjection.max, bProjection.max) - MathF.Max(aProjection.min, bProjection.min);

                if (overlap < penetration)
                {
                    penetration = overlap;
                    collisionNormal = normal;
                }
            }

            Collision collision = new Collision(a, b, collisionNormal, penetration);
            Console.WriteLine("Collision Detected!");
            return collision;
        }

        private Collision DetectCircleCollision(Collider a, Collider b)
        {
            Vector2 aCenter = a.GameObject.Transform.Position;
            float aRadious = a.GameObject.Transform.Scale.X * 0.5f;

            Vector2 bCenter = b.GameObject.Transform.Position;
            float bRadious = b.GameObject.Transform.Scale.X * 0.5f;

            Vector2 difference = aCenter - bCenter;
            float distance = difference.Length();

            float totalRadious = aRadious + bRadious;

            if(totalRadious < distance)
            {
                return null;
            }

            Console.WriteLine("Collision Detected!");
            Collision collision = new Collision(a, b, Vector2.Normalize(difference), totalRadious - distance);

            return collision;
        }

        private Collision DetectCircleConvexCollision(Collider a, Collider b)
        {
            Collider rect = a.shape == CollisionShape.Square ? a : b;
            Collider circle = a.shape == CollisionShape.Circle ? a : b;

            Vector2 circleCenter = circle.GameObject.Transform.Position;

            Vector2 rectCenter = rect.GameObject.Transform.Position;
            Vector2 rectSize = rect.GameObject.Transform.Scale;

            Vector2 rectMin = rectCenter - rectSize / 2;
            Vector2 rectMax = rectCenter + rectSize / 2;

            float closestX = MathF.Max(rectMin.X, MathF.Min(rectMax.X, circleCenter.X));
            float closestY = MathF.Max(rectMin.Y, MathF.Min(rectMax.Y, circleCenter.Y));
            Vector2 closestPoint = new Vector2(closestX, closestY);

            Vector2 difference = circleCenter - closestPoint;
            float distance = difference.Length();

            float circleRadious = circle.GameObject.Transform.Scale.X * 0.5f;

            if (distance > circleRadious)
                return null;

            Collision collision = new Collision(a, b, Vector2.Normalize(difference), circleRadious - distance);
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
