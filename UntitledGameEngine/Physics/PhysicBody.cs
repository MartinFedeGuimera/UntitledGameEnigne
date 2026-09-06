using System.Numerics;
using UntitledGameEngine.Core;

namespace UntitledGameEngine.Physics
{
<<<<<<< Updated upstream
    public class PhysicBody : Component
=======
    public abstract class PhysicBody : Component
>>>>>>> Stashed changes
    {
        public float mass = 1.0f;
        public float gravity = -9.8f;
        public bool useGravity = true;

        public Vector2 velocity = new Vector2(0.0f, 0.0f);
        public virtual void OnCollide(Collision collision) { }
    }
}
