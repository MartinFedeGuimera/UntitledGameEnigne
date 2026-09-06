using System.Numerics;

namespace UntitledGameEngine.Physics
{
    public class Collision
    {
        public Collider ColliderA { get; }
        public Collider ColliderB { get; }

        public Vector2 Normal { get; }
        public float Penetration { get; }

        public Collision(Collider colliderA, Collider colliderB, Vector2 normal, float penetration)
        {
            ColliderA = colliderA;
            ColliderB = colliderB;
            Normal = normal;
            Penetration = penetration;
        }
    }
}
