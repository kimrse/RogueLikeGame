using RogueLikeGame.GameObjects.Base;

namespace RogueLikeGame.GameCore.InputController
{
    internal class InputHandler
    {
        public Entity Player { get; private set; }

        public InputManager Input { get; private set; }

        public InputHandler(Entity player, InputManager input)
        {
            Input = input;
            Player = player;

            Input.OnMove += Player.Move;
        }
    }
}
