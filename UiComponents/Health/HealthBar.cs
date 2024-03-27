using RogueLikeGame.Utils.Enums;

namespace RogueLikeGame.UiComponents.Health
{
    public class HealthBar
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int HealthBarColor { get; set; }

        public HealthBar(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            HealthBarColor = (int)HealthBarColorEnum.Green;
        }

        public void decreaseHp(int damage)
        {
            CurrentHealth -= damage;
            updateColor();
            if (CurrentHealth < 0) CurrentHealth = 0;
        }

        private void updateColor()
        {
            if (CurrentHealth <= 70) HealthBarColor = (int)HealthBarColorEnum.Yellow;
            else if (CurrentHealth <= 30) HealthBarColor = (int)HealthBarColorEnum.Red;
        }
    }
}
