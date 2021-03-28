using System;

namespace Makruul
{
    
    public class Ghoul : Monster
    {
        public Ghoul() : base(12, 135, 22, 45)
        {
            name = "Hideous Ghoul";
            health = new Random().Next(85, 110);
        }
    }
}