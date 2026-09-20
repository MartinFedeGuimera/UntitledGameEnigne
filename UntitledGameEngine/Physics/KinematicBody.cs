using System.Numerics;
using UntitledGameEngine.Core;

namespace UntitledGameEngine.Physics
{
    public class KinematicBody : PhysicBody
    {
        public override void OnCollide(Collision collision)
        {
            bool isColliderA = collision.ColliderA == GameObject.GetComponent<Collider>();

            Collider oppositeCollider = isColliderA ? collision.ColliderB : collision.ColliderA;

            Vector2 normal = isColliderA ? collision.Normal : -collision.Normal;

            if (oppositeCollider.GameObject.GetComponent<StaticBody>() != null)
            {
                GameObject.Transform.Position -= normal * collision.Penetration;

                float velocityIntoSurface = Vector2.Dot(velocity, normal);

                if(velocityIntoSurface > 0)
                {
                    velocity -= normal * velocityIntoSurface;
                }
            }
        }

        public override void FixedUpdate(float fixedDeltaTime)
        {
            GameObject.Transform.Position += velocity * fixedDeltaTime;
        }
    }
}
