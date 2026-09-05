using UntitledGameEngine.Render;

namespace UntitledGameEngine.Objects.GameObject
{
    public abstract class Component
    {
        public string Name { get; set; }
        public GameObject GameObject {  get; internal set; }

        public virtual void Start() { }

        public virtual void Update(float deltaTime) { }

        public virtual void Render(RenderSystem renderSystem) { }
    }
}
