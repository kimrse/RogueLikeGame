using RogueLikeGame.GameObjects.Base;
using RogueLikeGame.Utils;
using RogueLikeGame.Managers.ObjectManager;
using RogueLikeGame.Utils.Enums;
using RogueLikeGame.GameObjects.Props;

namespace RogueLikeGame.GameObjects.Enemy
{
    internal class MeleeEnemy : Entity
    {
        private int attackColldown = 1000;
        private DateTime lastAttack;

        private double elapsedTimeSinceLastMove;
        private double moveCooldown = 20; 

        public MeleeEnemy(Position position, bool isSolid, int hp = 20, char sprite = (char) SpriteEnum.MEELE_ENEMY)
            : base(position, isSolid, hp, sprite)
        {
        }

        private void Attack()
        {
        }

        public override void Update(double deltaTime)
        {
            elapsedTimeSinceLastMove += deltaTime;

            if (elapsedTimeSinceLastMove >= moveCooldown)
            {
                Move(GenerateRandomDirection());
                elapsedTimeSinceLastMove = 0; 
            }
        }

        public override void Move(DirectionEnum direction)
        {
            Position newPosition;

            switch (direction)
            {
                case DirectionEnum.Up:
                    newPosition = Position + Position.Up;
                    break;
                case DirectionEnum.Down:
                    newPosition = Position + Position.Down;
                    break;
                case DirectionEnum.Left:
                    newPosition = Position + Position.Left;
                    break;
                case DirectionEnum.Right:
                    newPosition = Position + Position.Right;
                    break;
                default:
                    return;
            }

            if (gameObjectManager.IsPositionFree(newPosition))
            {
                Position = newPosition;
            }
        }

        protected DirectionEnum GenerateRandomDirection()
        {
            Random random = new Random();
            int direction = random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    return DirectionEnum.Up;
                case 1:
                    return DirectionEnum.Down;
                case 2:
                    return DirectionEnum.Left;
                case 3:
                    return DirectionEnum.Right;
                default:
                    return DirectionEnum.Up;
            }
        }
    }
}
