using RogueLikeGame.Utils;
using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.GameObjects.Base
{
    public class Entity : GameObject
    {
        public event Action<int> OnDamageTaken;

        private int hp;

        public int Hp
        {
            get => hp;
            protected set
            {
                hp = value;
                if (hp <= 0)
                {
                    Kill();
                }
            }
        }

        public Entity(Position position, bool isSolid, int hp, char sprite)
            : base(position,isSolid, sprite)
        {
            this.hp = hp;
            base.Sprite = sprite;
        }

        public virtual void RecieveDamage(int damage)
        {
            Hp -= damage;
            OnDamageTaken?.Invoke(damage);
        }

        public virtual void Move(DirectionEnum direction)
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
    }
}
