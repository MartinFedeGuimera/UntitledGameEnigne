using UntitledGameEngine.Core;

namespace Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameSettings settings = new GameSettings
            {
                Width = 800,
                Height = 600,
                Title = "Pong"
            };


            PongGame pong = new PongGame(settings);      
            pong.Run();
        }
    }
}
