namespace Makruul
{
    public class Weapon
    {
        public int damageBonus { get; }
        public string name;

        public Weapon(int damageBonus, string name)
        {
            this.damageBonus = damageBonus;
            this.name = name;
        }
    }
}