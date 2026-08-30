using OpenTK.Mathematics;

namespace Pong
{
    internal class ColliderSystem
    {
        private List<Collider> colliders = new List<Collider>();

        public void AddCollider(Collider collider)
        {
            colliders.Add(collider);
        }

        
    }
}
