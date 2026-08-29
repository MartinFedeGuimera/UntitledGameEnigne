using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Pong
{
    internal static class Input
    {
        private static KeyboardState currentState;
        private static KeyboardState previousState;

        public static void Update(KeyboardState keyboardState)
        {
            previousState = currentState;
            currentState = keyboardState;
        }

        public static bool IsKeyDown(Keys key) =>
            currentState.IsKeyDown(key);

        public static bool IsKeyPressed(Keys key) =>
            currentState.IsKeyDown(key) &&
            !previousState.IsKeyDown(key);

        public static bool IsKeyReleased(Keys key) =>
            !currentState.IsKeyDown(key) &&
            previousState.IsKeyDown(key);
    }
}