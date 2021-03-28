using System;

namespace Makruul
{
    public class Wolf : Monster
    {
        public Wolf(): this(8, 120)
        {
        }

        public Wolf(int baseDmg, int experienceGiven) : base(baseDmg, experienceGiven)
        {
            health = 60;
            name = "Angry Wolf";
        }
        
    }
}