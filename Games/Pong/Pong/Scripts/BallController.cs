using UntitledGameEngine.Core;
using System.Numerics;
using UntitledGameEngine.Physics;

namespace Pong.Scripts
{
    internal class BallController : MonoBehaviour
    {
        private RigidBody body;
        private float speed = 200;

        private bool respawning = false;
        private float respawnTimer = 1f;

        public override void Start()
        {
            body = GameObject.GetComponent<RigidBody>();

            DecideRanDirection();
        }

        public override void Update(float deltaTime)
        {
            if(respawning)
            {
                respawnTimer -= deltaTime;

                if(respawnTimer <= 0f)
                {
                    respawning = false;
                    Respawn();
                }

                return;
            }

            if (GameObject.Transform.Position.X > 810)
            {
                StartRespawn();
            }
            else if (GameObject.Transform.Position.X < 0)
            {
                StartRespawn();
            }
        }

        private void StartRespawn()
        {
            respawning = true;
            respawnTimer = 1f;
        }

        private void Respawn()
        {
            GameObject.Transform.Position = new Vector2(400, 300);
            DecideRanDirection();
        }

        private void DecideRanDirection()
        {
            Random rnd = new Random();
            float randomNum = (float)rnd.NextDouble();

            if (randomNum >= 0.5f)
            {
                body.velocity = Vector2.One * speed;
            }
            else
            {
                body.velocity = -Vector2.One * speed;
            }
        }
    }
}
