using System.Drawing;
using UntitledGameEngine.Core;

namespace Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PongGame pong = new PongGame();

            pong.Run();
        }
    }
}
