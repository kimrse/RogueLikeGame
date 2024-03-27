using RogueLikeGame.GameObjects.Base;
using RogueLikeGame.Utils;
using RogueLikeGame.Managers.ObjectManager;
using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.GameObjects.Props
{
    public class Wall : GameObject
    {
        public Wall(Position position, bool isSolid, char sprite = (char) SpriteEnum.WALL)
            : base(position, isSolid, sprite)
        {
        }
    }
}
