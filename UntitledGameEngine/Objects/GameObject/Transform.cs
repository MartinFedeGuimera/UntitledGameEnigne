using System.Numerics;

namespace UntitledGameEngine.Core
{
    public class Transform
    {
        private Vector2 position = new Vector2(0, 0);
        private Vector2 rotation = new Vector2(0, 0);
        private Vector2 scale = new Vector2(25, 25);

        public Vector2 Position { get { return position; } set { position = value; } }
        public Vector2 Rotation { get { return rotation; } set { rotation = value; } }
        public Vector2 Scale { get { return scale; } set { scale = value; } }
    }
}
