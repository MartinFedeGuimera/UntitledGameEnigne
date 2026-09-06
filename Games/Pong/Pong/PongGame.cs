using UntitledGameEngine.Core;
using UntitledGameEngine.Rendering;
using System.Drawing;
using UntitledGameEngine.Physics;
using System.Numerics;

namespace Pong
{
    internal class PongGame : Game
    {
        public PongGame(GameSettings gameSettings) : base(gameSettings) {}

        private GameObject leftPaddle = new GameObject("LeftPaddle");
        private GameObject rightPaddle = new GameObject("RightPaddle");
        private GameObject ball = new GameObject("Ball");

        public override void Start()
        {
            leftPaddle.AddComponent<Renderer>().shape = Shape.Square;
            leftPaddle.AddComponent<Collider>().shape = CollisionShape.Square;
            leftPaddle.AddComponent<KinematicBody>();

            leftPaddle.Transform.Position = new Vector2(50, 300);
            leftPaddle.Transform.Scale = new Vector2(25, 100);

            rightPaddle.AddComponent<Renderer>().shape = Shape.Square;

            rightPaddle.AddComponent<Collider>().shape = CollisionShape.Square;
            rightPaddle.AddComponent<KinematicBody>();

            rightPaddle.Transform.Position = new Vector2(750, 300);
            rightPaddle.Transform.Scale = new Vector2(25, 100);

            ball.AddComponent<Renderer>().shape = Shape.Circle;
            ball.AddComponent<Collider>().shape = CollisionShape.Circle;
            ball.AddComponent<RigidBody>().useGravity = false;
            ball.GetComponent<RigidBody>().velocity = new Vector2(50, 0);

            ball.Transform.Position = new Vector2(400, 300);
            ball.Transform.Scale = new Vector2(25, 25);

            mainScene.AddGameObject(ball);
            mainScene.AddGameObject(leftPaddle);
            mainScene.AddGameObject(rightPaddle);

            base.Start();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Render()
        {
            base.Render();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }
    }
}
