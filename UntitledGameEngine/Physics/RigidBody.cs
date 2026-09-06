using System.Numerics;

namespace UntitledGameEngine.Physics
{
    public class RigidBody : PhysicBody
    {
        public override void OnCollide(Collision collision) 
        {
            GameObject.Transform.Position += collision.Normal * collision.Penetration;

            velocity = Vector2.Reflect(velocity, collision.Normal);
        }

        public override void Update(float deltaTime)
        {
            if(useGravity)
                velocity.Y -= gravity * mass;

            GameObject.Transform.Position += velocity * deltaTime;
        }
    }
}
