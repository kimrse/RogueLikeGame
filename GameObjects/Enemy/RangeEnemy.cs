using RogueLikeGame.Utils;
using RogueLikeGame.GameObjects.Props;
using RogueLikeGame.Managers.ObjectManager;
using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.GameObjects.Enemy
{
    internal class RangeEnemy : MeleeEnemy
    {
        private int attackColldown = 1000;
        private DateTime lastAttack;

        private static readonly Random random = new Random();

        public RangeEnemy(Position position, bool isSolid, int hp = 20, char sprite = (char) SpriteEnum.RANGE_ENEMY)
            : base(position, isSolid, hp, sprite)
        {
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Attack();
        }

        protected virtual void Attack()
        {
            if ((DateTime.Now - lastAttack).TotalMilliseconds >= attackColldown)
            {
                Bullet bullet = new Bullet(Position, false, (char) SpriteEnum.BULLET, GetBulletVelocity());
                gameObjectManager.RegisterGameObject(bullet);
                lastAttack = DateTime.Now;
            }
        }

        private Position GetBulletVelocity()
        {
            int direction = random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    return Position.Up;
                case 1:
                    return Position.Down;
                case 2:
                    return Position.Left;
                case 3:
                    return Position.Right;
                default:
                    return Position.Up;
            }
        }
    }
}
