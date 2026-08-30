using OpenTK.Mathematics;

namespace Pong
{
    internal class Transform
    {
        private Vector2 position;
        private Vector2 rotation;
        private Vector2 scale;

        public Vector2 Position { get { return position; } set { position = value; } }
        public Vector2 Rotation { get { return rotation; } set { rotation = value; } }
        public Vector2 Scale { get { return scale; } set { scale = value; } }
    }
}
