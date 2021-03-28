using System;

namespace Makruul
{
    public class Wolf : Monster
    {
        public Wolf() : base(8, 120, 8, 16)
        {
            health = 60;
            name = "Angry Wolf";
        }
    }
    
}