using RogueLikeGame.Utils;
using RogueLikeGame.Managers.ObjectManager;

namespace RogueLikeGame.GameObjects.Base
{
    public class GameObject
    {
        public Position Position { get; protected set; }
        public char Sprite { get; protected set; }
        public bool IsSolid { get; protected set; }
        public GameObjectManager gameObjectManager { get; private set; }

        public event Action<GameObject> onGameObjectDestroyed;
        public event Action onCollisionHit;

        public GameObject(Position position, bool isSolid, char sprite = ' ')
        {
            gameObjectManager = GameObjectManager.getObjectManagerInstance;
            Position = position;
            Sprite = sprite;
            IsSolid = isSolid;
            onGameObjectDestroyed += OnKill;
            onCollisionHit += OnCollisionHit;
        }

        public virtual void Update(double deltaTime)
        {
            CheckCollision();
        }
        public virtual void OnKill(GameObject obj)
        {

        }

        public virtual void OnCollisionHit()
        {

        }

        public void Kill()
        {
            onGameObjectDestroyed?.Invoke(this);
        }

        private void CheckCollision()
        {
            for (int i = gameObjectManager.GameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = gameObjectManager.GameObjects[i];
                if (gameObject != this && gameObject.Position.Equals(Position))
                {
                    onCollisionHit?.Invoke();
                }
            }
        }
    }
}
