using UntitledGameEngine.Objects.GameObject;
using System.Drawing;

namespace UntitledGameEngine.Render
{
    public enum Shape
    {
        None,
        Square,
        Circle,
        Triangle
    }

    internal class Renderer : Component
    {
        public Shape shape = Shape.None;
        public Color color = Color.White;

        public override void Render(RenderSystem renderSystem)
        {
            switch(shape)
            {
                case Shape.Square:
                    renderSystem.DrawSquare(GameObject.Transform.Position, GameObject.Transform.Scale, color);
                    break;
                case Shape.Circle:
                    renderSystem.DrawCircle(GameObject.Transform.Position, GameObject.Transform.Scale, color);
                    break;
                case Shape.Triangle:
                    Console.WriteLine("No Triangle drawing function in RenderSystem");
                    break;
            }
        }
    }
}
