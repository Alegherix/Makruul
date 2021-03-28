namespace Makruul
{
    
    public class Makruul : Monster
    {
        public Makruul(): this(18, 500)
        {
        }
        
        public Makruul(int baseDmg, int experienceGiven) : base(baseDmg, experienceGiven)
        {
            health = 250;
            name = "Makruul the gruesome";
        }
    }
}