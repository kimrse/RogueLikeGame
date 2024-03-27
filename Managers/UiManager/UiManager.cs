using RogueLikeGame.GameCore.View;
using RogueLikeGame.GameObjects.Base;
using RogueLikeGame.GameObjects.Player;
using RogueLikeGame.Managers.ObjectManager;
using RogueLikeGame.UiComponents.Health;
using System.Numerics;

namespace RogueLikeGame.Managers.UiManager
{
    internal class UiManager
    {
        
        private readonly GameObjectManager gameObjectManager = GameObjectManager.getObjectManagerInstance;
        public HealthBar healthBar { get; set; }

        private static UiManager uiManagerInstance = null;

        public static UiManager getUiManagerInstance
        {
            get
            {
                if (uiManagerInstance == null)
                {
                    uiManagerInstance = new UiManager();
                }
                return uiManagerInstance;
            }
        }

        private UiManager()
        {
            healthBar = new HealthBar(gameObjectManager.Player.Hp);
            HealthBarHandler healthBarHandler = new HealthBarHandler(healthBar, gameObjectManager.Player);
            healthBarHandler.updateHealthBar();
        }
    }
}
