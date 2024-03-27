using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.GameCore.InputController
{
    internal class InputManager
    {
        public event Action<DirectionEnum> OnMove;

        public void ReadInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        OnMove?.Invoke(DirectionEnum.Up);
                        break;
                    case ConsoleKey.S:
                        OnMove?.Invoke(DirectionEnum.Down);
                        break;
                    case ConsoleKey.A:
                        OnMove?.Invoke(DirectionEnum.Left);
                        break;
                    case ConsoleKey.D:
                        OnMove?.Invoke(DirectionEnum.Right);
                        break;
                }
            }
        }

        public InputManager()
        {
        }
    }
}
