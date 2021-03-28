using System;
using System.Collections.Generic;

namespace Makruul
{
    public class Player : Entity
    {
        
        public List<Region> VisitedRegions { get; set; }

    
        private List<Food> _foods;

        private int Experience { get; set; }
        private int _level = 1;
        private int _baseDmg = 15;
        private int baseHealth;
        private Weapon equipedWeapon;
        private List<Weapon> Weapons => _weapons;
        private readonly List<Weapon> _weapons;
        
        public int goldCoins;
        


        public Player(string name)
        {
            health = 100;
            baseHealth = 100;
            goldCoins = 250;
            _weapons = new List<Weapon>();
            _foods = new List<Food>();
            this.name = name;
            VisitedRegions = new List<Region>();
            equipedWeapon = Resources.treeSword;
            Weapons.Add(Resources.treeSword);
       
        }

        public void GainExperience(int experience)
        {
            this.Experience += experience;
            if (ShouldLevelUp()) LevelUp();
        }

        private void LevelUp()
        {
            var newLevel = Experience / 100;
            for (int i = _level; i <= newLevel; i++)
            {
                var bonusHealth = 15;
                var bonusDamage = 5;
                
                _level++;
                baseHealth += bonusHealth;
                _baseDmg += bonusDamage;
                Console.WriteLine($"You level up to Level {_level} gaining {bonusHealth} health and {bonusDamage} baseDamage");
            }
        }

        public void Eat()
        {
            
        }

        public void AddWeapon(Weapon weapon)
        {
            _weapons.Add(weapon);
            EquipWeapon(weapon);
        }

        private void EquipWeapon(Weapon weapon)
        {
            equipedWeapon = weapon;
        }

        public void AddFood(Food food)
        {
            _foods.Add(food);
        }

        public void PayForItem(int amount)
        {
            this.goldCoins -= amount;
        }

        private Boolean ShouldLevelUp()
        {
            return Experience > (_level * 100);
        }

        public override int Attack<T>(T entity)
        {
            var dmg =  new Random().Next(_baseDmg, (_baseDmg + equipedWeapon.damageBonus));
            entity.health -= dmg;
            return dmg;
        }
        

        public override string ToString()
        {
            return $"" +
                   $"Health: {baseHealth}/{health} Hp remaining\n" +
                   $"Currently equiped: ${equipedWeapon}\n" +
                   $"Currently Lvl: {_level}\n" +
                   $"Goldcoins: ${goldCoins}" ;
        }
    }
}