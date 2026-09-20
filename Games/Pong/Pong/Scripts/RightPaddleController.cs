using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Numerics;
using UntitledGameEngine.Core;
using UntitledGameEngine.Physics;

namespace Pong.Scripts
{
    internal class RightPaddleController : MonoBehaviour
    {
        private KinematicBody body;
        private float speed = 300.0f;

        public override void Start()
        {
            body = GameObject.GetComponent<KinematicBody>();
        }

        public override void FixedUpdate(float fixedDeltaTime)
        {
            if (Input.IsKeyDown(Keys.Up))
            {
                body.velocity = new Vector2(0, -1) * speed;
            }
            else if (Input.IsKeyDown(Keys.Down))
            {
                body.velocity = new Vector2(0, 1) * speed;
            }
            else
            {
                body.velocity = Vector2.Zero;
            }
        }
    }
}
