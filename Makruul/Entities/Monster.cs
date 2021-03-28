using System;

namespace Makruul
{
    public abstract class Monster : Entity
    {
        protected readonly int baseDmg;
        public int ExperienceGiven { get;}
        
        protected Monster(int baseDmg, int experienceGiven)
        {
            this.baseDmg = baseDmg;
            this.ExperienceGiven = experienceGiven;
        }

        public override int Attack<T>(T entity)
        {
            var dmg =  new Random().Next(baseDmg, (int) (baseDmg * 1.2));
            entity.health -= dmg;
            return dmg;
        }

        public override string ToString()
        {
            return $"Health: {health}";
        }
    }
}