using System.Drawing;
using UntitledGameEngine.Physics;
using UntitledGameEngine.Rendering;

namespace UntitledGameEngine.Core
{
    public class Game
    {
        public RenderSystem renderSystem = new RenderSystem();
        public CollisionSystem collisionSystem = new CollisionSystem();

        public Scene mainScene = new Scene("MainScene");

        EngineWindow window;

        public Game(GameSettings gameSettings)
        {
            window = new EngineWindow(this, gameSettings);
        }

        public void Run()
        {
            window.Run();
        }

        public virtual void Start() 
        {
            renderSystem.Initialize();
            renderSystem.SetViewportSize(window.Size.X, window.Size.Y);

            mainScene.Start();
        }

        public virtual void Update(float deltaTime) 
        {
            collisionSystem.Update();

            mainScene.Update(deltaTime);
        }

        public virtual void Render() 
        {
            renderSystem.BeginFrame();

            mainScene.Render(renderSystem);
        }

        public virtual void UnLoad()
        {
            renderSystem.Dispose();
        }

        public virtual void OnFramebufferResize(int width, int height)
        {
            renderSystem.SetViewportSize(width, height);
        }
    }
}
