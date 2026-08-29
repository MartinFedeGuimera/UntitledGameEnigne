namespace Pong
{
    internal abstract class Component
    {
        public string Name { get; set; }
        public GameObject GameObject {  get; internal set; }

        public virtual void Start() { }

        public virtual void Update(float deltaTime) { }
    }
}
