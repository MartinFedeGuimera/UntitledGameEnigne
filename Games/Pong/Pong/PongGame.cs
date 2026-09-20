using UntitledGameEngine.Core;
using UntitledGameEngine.Rendering;
using UntitledGameEngine.Physics;
using System.Numerics;
using Pong.Scripts;

namespace Pong
{
    internal class PongGame : Game
    {
        public PongGame(GameSettings gameSettings) : base(gameSettings) {}

        private GameObject leftPaddle = new GameObject("LeftPaddle");
        private GameObject rightPaddle = new GameObject("RightPaddle");
        private GameObject ball = new GameObject("Ball");

        private GameObject ceiling = new GameObject("Ceiling");
        private GameObject floor = new GameObject("Floor");

        public override void Start()
        {
            leftPaddle.AddComponent<Renderer>().shape = Shape.Square;
            leftPaddle.AddComponent<Collider>().shape = CollisionShape.Square;
            leftPaddle.AddComponent<KinematicBody>();
            leftPaddle.AddComponent<LeftPaddleController>();

            leftPaddle.Transform.Position = new Vector2(50, 300);
            leftPaddle.Transform.Scale = new Vector2(25, 100);

            rightPaddle.AddComponent<Renderer>().shape = Shape.Square;
            rightPaddle.AddComponent<Collider>().shape = CollisionShape.Square;
            rightPaddle.AddComponent<KinematicBody>();
            rightPaddle.AddComponent<RightPaddleController>();

            rightPaddle.Transform.Position = new Vector2(750, 300);
            rightPaddle.Transform.Scale = new Vector2(25, 100);

            ball.AddComponent<Renderer>().shape = Shape.Circle;
            ball.AddComponent<Collider>().shape = CollisionShape.Circle;
            ball.AddComponent<RigidBody>().useGravity = false;
            ball.AddComponent<BallController>();

            ball.Transform.Position = new Vector2(400, 300);
            ball.Transform.Scale = new Vector2(25, 25);

            ceiling.AddComponent<Collider>().shape = CollisionShape.Square;
            ceiling.AddComponent<StaticBody>();

            ceiling.Transform.Position = new Vector2(400, -5);
            ceiling.Transform.Scale = new Vector2(800, 10);

            floor.AddComponent<Collider>().shape = CollisionShape.Square;
            floor.AddComponent<StaticBody>();

            floor.Transform.Position = new Vector2(400, 605);
            floor.Transform.Scale = new Vector2(800, 10);

            mainScene.AddGameObject(ball);
            mainScene.AddGameObject(leftPaddle);
            mainScene.AddGameObject(rightPaddle);
            mainScene.AddGameObject(ceiling);
            mainScene.AddGameObject(floor);

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
