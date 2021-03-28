using System;
using System.Collections.Generic;

namespace Makruul
{
    public class Player : Entity, IOption
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

        public void Eat(Food food)
        {
            // Makes sure not to overheal
            health = health + food.healing > baseHealth ? baseHealth : health += food.healing;

            _foods.Remove(food);
            Console.WriteLine($"You consume {food.name} healing you for {food.healing}");
            Console.WriteLine($"Current health: {health}/{baseHealth}");
        }

        public Food AskWhichFoodToEat()
        {
            Console.WriteLine($"Current health: {health}/{baseHealth}");
            Console.WriteLine("Which food do you want to consume?");
            for (int i = 0; i < _foods.Count; i++)
            {
                Console.WriteLine($"{i}) {_foods[i]}");
            }

            Console.Write("Enter your choice: ");
            int choice = GameUtils.GetNumberInput();
            if (choice >= 0 && choice < _foods.Count) return _foods[choice];
            return null;
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
                   $"Currently equiped: {equipedWeapon}\n" +
                   $"Currently Lvl: {_level}\n" +
                   $"Goldcoins: {goldCoins}\n" ;
        }

        public string[] GetOptions()
        {
            return new[]{"Show Player Stats", "Show Player Inventory", "Consume bought food"};
        }

        public void PerformOption(int option)
        {
            switch (option)
            {
                case 0: Console.WriteLine(this); 
                    break;
                case 1:
                {
                    Console.WriteLine("In your inventory there's currently: ");
                    _foods.ForEach(Console.WriteLine);
                    break;
                }
                case 2:
                {
                    if (_foods.Count > 0)
                    {
                        var food = AskWhichFoodToEat();
                        if(food != null) Eat(food);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
        
    }
}