using System.Numerics;

namespace Pong
{
    internal class Transform
    {
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;

        public Vector3 Position { get { return position; }
            set { position = value; } }
        public Vector3 Rotation { get { return rotation; } set { rotation = value; } }
        public Vector3 Scale { get { return scale; } set { scale = value; } }
    }
}
