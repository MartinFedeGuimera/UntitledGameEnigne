using UntitledGameEngine.Render;

namespace UntitledGameEngine.Objects.GameObject
{
    public class Scene
    {
        private List<GameObject> gameObjects = new List<GameObject>();

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void Start()
        {
            foreach(var gameObject in gameObjects)
            {
                gameObject.Start();
            }
        }

        public void Update(float deltaTime)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(deltaTime);
            }
        }

        public void Render(RenderSystem renderSystem)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Render(renderSystem);
            }
        }
    }
}
