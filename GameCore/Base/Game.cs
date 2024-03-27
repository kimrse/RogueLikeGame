using RogueLikeGame.GameCore.InputController;
using RogueLikeGame.GameCore.View;
using RogueLikeGame.Managers.ObjectManager;
using RogueLikeGame.Managers.UiManager;
using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.GameCore.Base
{
    public class Game
    {
        private readonly GameObjectManager gameObjectManager;
        private readonly Renderer renderer;
        private static readonly Random random = new Random();

        private int enemyNumber = random.Next(5, 10);
        private int shootingEnemyNumber = random.Next(5, 10);
        private int wallsQuantity = random.Next(100, 300);

        public GameStateEnum gameState { get; private set; }

        InputManager input;
        InputHandler inputHandler;
        GameLoop gameLoop;

        public Game()
        {
            gameObjectManager = GameObjectManager.getObjectManagerInstance;
            gameObjectManager.initializeEntities(enemyNumber, shootingEnemyNumber, wallsQuantity);
            renderer = Renderer.getRendererInstance;
            input = new InputManager();
            inputHandler = new InputHandler(gameObjectManager.Player, input);

            gameObjectManager.OnPlayerDestroyed += OnPlayerDiedCallback;
            gameObjectManager.OnLevelCompleted += OnLevelCompleteCallback;

            gameState = GameStateEnum.ACTIVE;
            gameLoop = new GameLoop(Update, 120);
            gameLoop.Start();
        }

        public void Update(double deltaTime)
        {

            switch (gameState)
            {
                case GameStateEnum.ACTIVE:
                    input.ReadInput();
                    renderer.Render();
                    gameObjectManager.Update(deltaTime);
                    break;
                case GameStateEnum.DEFEAT:
                    renderer.RenderDefeat();
                    gameLoop.Stop();
                    break;
                case GameStateEnum.VICTORY:
                    renderer.RenderVictory();
                    gameLoop.Stop();
                    break;
            }
        }

        private void OnPlayerDiedCallback()
        {
            gameState = GameStateEnum.DEFEAT;
        }

        private void OnLevelCompleteCallback()
        {
            gameState = GameStateEnum.VICTORY;
        }
    }
}
