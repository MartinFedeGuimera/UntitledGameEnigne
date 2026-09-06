using UntitledGameEngine.Rendering;

namespace UntitledGameEngine.Core
{
    public class Scene
    {
        public string Name { get; set; }

        private List<GameObject> gameObjects = new List<GameObject>();

        public Scene(string name = "NewScene")
        {
            Name = name;
        }

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

        public void FixedUpdate(float fixedDeltaTime)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.FixedUpdate(fixedDeltaTime);
            }
        }

        public void Render(RenderSystem renderSystem)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Render(renderSystem);
            }
        }

        public List<GameObject> GetGameObjects() => gameObjects;
    }
}
