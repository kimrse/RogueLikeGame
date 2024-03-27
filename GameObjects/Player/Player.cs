using RogueLikeGame.GameObjects.Base;
using RogueLikeGame.Utils;
using RogueLikeGame.Managers.ObjectManager;
using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.GameObjects.Player
{
    internal class Player : Entity
    {

        public Player(Position position, bool isSolid, int hp = 100)
            : base(position, isSolid, hp, (char) SpriteEnum.PLAYER)
        {
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void OnKill(GameObject gameObject)
        {
            gameObjectManager.Kill(gameObject);
        }

        public override void OnCollisionHit()
        {
            RecieveDamage(20);
        }
    }
}
