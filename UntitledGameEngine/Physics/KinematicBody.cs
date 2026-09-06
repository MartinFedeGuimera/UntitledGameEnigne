using UntitledGameEngine.Core;

namespace UntitledGameEngine.Physics
{
    public class KinematicBody : PhysicBody
    {
        public override void OnCollide(Collision collision)
        {
            Collider oppositeCollider = collision.ColliderA == GameObject.GetComponent<Collider>() ? collision.ColliderB : collision.ColliderA;

            if (oppositeCollider.GameObject.GetComponent<StaticBody>() != null)
            {
                GameObject.Transform.Position += collision.Normal * collision.Penetration;
            }
        }

        public override void Update(float deltaTime)
        {
            GameObject.Transform.Position += velocity * deltaTime;
        }
    }
}
