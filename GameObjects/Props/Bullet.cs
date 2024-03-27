using RogueLikeGame.GameObjects.Base;
using RogueLikeGame.Utils;
using RogueLikeGame.Managers.ObjectManager;

namespace RogueLikeGame.GameObjects.Props
{
    internal class Bullet : GameObject
    {
        private Position velocity;

        public Bullet(Position position, bool isSolid, char sprite, Position velocity)
            : base(position, isSolid, sprite)
        {
            this.velocity = velocity;
        }

        public override void Update(double deltaTime)
        {
            Position nextPosition = Position + velocity;

            if (gameObjectManager.IsPositionFree(nextPosition))
            {
                Position = nextPosition;
            }
            else
            {
                Kill();
            }
        }

        public override void OnKill(GameObject obj)
        {
            gameObjectManager.Kill(obj);
        }
    }
}
