using UntitledGameEngine.Rendering;

namespace UntitledGameEngine.Core
{
    public class GameObject
    {
        public string Name;
        public Transform Transform;

        private List<Component> components = new List<Component>();

        public GameObject(string name)
        {
            Name = name;
            Transform = new Transform();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            component.GameObject = this;

            components.Add(component);

            return component;
        }

        public T GetComponent<T>() where T : Component, new()
        {
            foreach (Component component in components)
            {
                if (component is T)
                {
                    return (T)component;
                }
            }

            return null;
        }

        public void Start() 
        { 
            foreach(Component component in components)
            {
                component.Start();
            }
        }

        public void Update(float deltaTime) 
        {
            foreach(Component component in components)
            {
                component.Update(deltaTime);
            }
        }

        public void Render(RenderSystem renderSystem)
        {
            foreach(Component component in components)
            {
                component.Render(renderSystem);
            }
        }
    }
}
