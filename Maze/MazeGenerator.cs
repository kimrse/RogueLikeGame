using RogueLikeGame.GameObjects.Props;
using RogueLikeGame.Utils;
using RogueLikeGame.Managers.ObjectManager;
using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.Maze
{
    public class MazeGenerator
    {

        public int Width { get; private set; }
        public int Height { get; private set; }

        public List<Wall> Walls { get; private set; }
        public Position Exit { get; private set; }

        private GameObjectManager gameObjectManager;
        
        private int wallNumber;
        private char[,] mapGrid;
        private readonly Random random = new Random();

        public MazeGenerator(int wallNumber, int width = 50, int height = 25)
        {
            gameObjectManager = GameObjectManager.getObjectManagerInstance;
            this.wallNumber = wallNumber;
            Width = width;
            Height = height;
            mapGrid = new char[width, height];
            Walls = new List<Wall>();

            GenerateMaze();
        }

        public void GenerateMaze()
        {
            for (int i = 1; i < Width - 1; i++)
            {
                CreateWallProp(new Position(i, 0), (char)SpriteEnum.BORDER, true);
                CreateWallProp(new Position(i, Height - 1), (char)SpriteEnum.BORDER, true);
            }

            for (int i = 1; i < Height - 1; i++)
            {
                CreateWallProp(new Position(0, i), (char) SpriteEnum.BORDER, true);
                CreateWallProp(new Position(Width - 1, i), (char)SpriteEnum.BORDER, true);
            }


            for (int i = 0; i < wallNumber; i++)
            {
                CreateWallProp(GeneratePosition(), (char) SpriteEnum.WALL, true);
            }

            PlaceExit();
        }

        public void PlaceExit()
        {
            int side = random.Next(4);

            switch (side)
            {
                case 0:
                    Exit = new Position(random.Next(1, Width - 1), 0);
                    break;
                case 1:
                    Exit = new Position(random.Next(1, Width - 1), Height - 1);
                    break;
                case 2:
                    Exit = new Position(0, random.Next(1, Height - 1));
                    break;
                case 3:
                    Exit = new Position(Width - 1, random.Next(1, Height - 1));
                    break;
            }

            gameObjectManager.Kill(gameObjectManager.locateObject(Exit));

            CreateWallProp(Exit, (char) SpriteEnum.EXIT, false);
        }

        public Position GeneratePosition()
        {
            int maxAttempts = 100;
            int attempt = 0;

            while (attempt < maxAttempts)
            {
                int x = random.Next(2, Width - 2);
                int y = random.Next(1, Height - 1);

                Position randomPosition = new Position(x, y);

                if (gameObjectManager.IsPositionFree(randomPosition))
                {
                    return randomPosition;
                }

                attempt++;
            }
            return new Position(Width - 1, Height - 1);
        }

        private void CreateWallProp(Position position, char sprite, bool isSolid)
        {
            Wall wall = new Wall(position, isSolid, sprite);
            Walls.Add(wall);
            gameObjectManager.RegisterGameObject(wall);
        }
    }
}
