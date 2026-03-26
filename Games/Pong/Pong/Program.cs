using System;


namespace Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Game pong = new Game(800, 600, "Pong"))
            {
                pong.Run();
            }
        }
    }
}
