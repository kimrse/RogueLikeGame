using RogueLikeGame.GameObjects.Base;
using RogueLikeGame.GameObjects.Enemy;
using RogueLikeGame.GameObjects.Player;
using RogueLikeGame.Maze;
using RogueLikeGame.Utils;

namespace RogueLikeGame.Managers.ObjectManager
{
    public class GameObjectManager
    {

        public List<GameObject> GameObjects { get; private set; }

        public Entity Player { get; private set; }

        public Entity[] MeleeEnemies { get; private set; }

        public Entity[] RangeEnemies { get; private set; }

        public GameObject[] Walls { get; private set; }

        public MazeGenerator Maze { get; private set; }

        public event Action OnPlayerDestroyed;
        public event Action OnLevelCompleted;

        private static GameObjectManager objectManagerInstance = null;


        public static GameObjectManager getObjectManagerInstance
        {
            get
            {
                if (objectManagerInstance == null)
                {
                    objectManagerInstance = new GameObjectManager();
                }
                return objectManagerInstance;
            }
        }

        private GameObjectManager()
        {
            GameObjects = new List<GameObject>();
        }

        public void initializeEntities(int meleeEnemyCount, int RangeEnemyCount, int wallsQuantity)
        {

            MeleeEnemies = new Entity[meleeEnemyCount];
            RangeEnemies = new Entity[RangeEnemyCount];
            Maze = new MazeGenerator(wallsQuantity);

            Player = new Player(new Position(1, 1), false);
            RegisterGameObject(Player);

            for (int i = 0; i < MeleeEnemies.Length; i++)
            {
                MeleeEnemies[i] = new MeleeEnemy(Maze.GeneratePosition(), false);
                RegisterGameObject(MeleeEnemies[i]);
            }

            for (int i = 0; i < RangeEnemies.Length; i++)
            {
                RangeEnemies[i] = new RangeEnemy(Maze.GeneratePosition(), false);
                RegisterGameObject(RangeEnemies[i]);
            }
        }

        public void Update(double deltaTime)
        {
            for (int i = GameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = GameObjects[i];
                gameObject.Update(deltaTime);
            }

            if (!GameObjects.Contains(Player))
            {
                OnPlayerDestroyed?.Invoke();
            }

            if (Player.Position.Equals(Maze.Exit))
            {
                OnLevelCompleted?.Invoke();
            }
        }

        public bool IsPositionFree(Position position)
        {
            for (int i = GameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = GameObjects[i];
                if (gameObject.Position.Equals(position) && gameObject.IsSolid)
                {
                    return false;
                }
            }

            return true;
        }


        public void RegisterGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void Kill(GameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

        public GameObject? locateObject(Position position)
        {
            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject.Position.Equals(position))
                    return gameObject;
            }
            return null;
        }

        public void reset()
        {
            objectManagerInstance = new GameObjectManager();
        }
    }
}
