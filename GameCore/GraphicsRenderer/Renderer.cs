using RogueLikeGame.GameObjects.Base;
using RogueLikeGame.Managers.ObjectManager;
using RogueLikeGame.Managers.UiManager;
using RogueLikeGame.Utils;

namespace RogueLikeGame.GameCore.View
{
    internal class Renderer
    {
        private readonly GameObjectManager gameObjectManager;
        private readonly UiManager uiManager;

        private int width;
        private int height;
        private char[,] mazeBuffer;

        private static Renderer rendererInstance = null;


        public static Renderer getRendererInstance
        {
            get
            {
                if (rendererInstance == null)
                {
                    rendererInstance = new Renderer();
                }
                return rendererInstance;
            }
        }

        private Renderer()
        {
            gameObjectManager = GameObjectManager.getObjectManagerInstance;
            uiManager = UiManager.getUiManagerInstance;

            width = gameObjectManager.Maze.Width;
            height = gameObjectManager.Maze.Height;
            mazeBuffer = new char[width, height];
        }

        public void Render()
        {
            RenderHealthBar();
            UpdateMapBuffer();
            RenderMaze();
        }

        public void RenderDefeat()
        {
            Console.Clear();
            Console.WriteLine("You died");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }

        public void RenderVictory()
        {
            Console.Clear();
            Console.WriteLine("Victory!!!");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }

        private void RenderMaze()
        {
            Console.SetCursorPosition(0, 0);
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(mazeBuffer[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void UpdateMapBuffer()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mazeBuffer[i, j] = ' ';
                }
            }

            for (int i = gameObjectManager.GameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = gameObjectManager.GameObjects[i];
                Position position = gameObject.Position;
                char sprite = gameObject.Sprite;
                if (position.X >= 0 && position.X < width && position.Y >= 0 && position.Y < height)
                {
                    mazeBuffer[position.X, position.Y] = sprite;
                }
            }
        }

        private void RenderHealthBar()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.ForegroundColor = (ConsoleColor)uiManager.healthBar.HealthBarColor;
            Console.Write($"Health: {uiManager.healthBar.CurrentHealth} / {uiManager.healthBar.MaxHealth}");
            Console.ResetColor();
        }
    }
}
