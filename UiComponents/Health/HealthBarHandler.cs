using RogueLikeGame.GameObjects.Base;
using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.UiComponents.Health;

public class HealthBarHandler(HealthBar healthBar, Entity player)
{
    private HealthBar healthBar = healthBar;
    private readonly Entity player = player;

    public void updateHealthBar() 
    {
        player.OnDamageTaken += healthBar.decreaseHp;
    }


}
