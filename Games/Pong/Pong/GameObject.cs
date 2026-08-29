namespace Pong
{
    internal class GameObject
    {
        public string Name;
        private Transform Transform;

        public GameObject(string name)
        {
            Name = name;
            Transform = new Transform();
        }

        public void Start() { }

        public void Update() { }
    }
}
