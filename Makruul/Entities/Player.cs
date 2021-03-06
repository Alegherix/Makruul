using System;
using System.Collections.Generic;

namespace Makruul
{
    public class Player : Entity, IOption
    {
        private List<Food> _foods;
        private int Experience { get; set; }
        public int Level = 1;
        private int _baseDmg = 15;
        private int baseHealth;
        private Weapon _equipedWeapon;
        public int goldCoins;

        public Player(string name)
        {
            health = 100;
            baseHealth = 100;
            goldCoins = 250;
            _foods = new List<Food>();
            this.name = name;
            _equipedWeapon = new Weapon(5, "Tree sword");
        }

        public void GainExperience(int experience)
        {
            this.Experience += experience;
            if (ShouldLevelUp()) LevelUp();
        }

        private void LevelUp()
        {
            var newLevel = Experience / 100;
            for (int i = Level; i <= newLevel; i++)
            {
                var bonusHealth = 15;
                var bonusDamage = 5;
                
                Level++;
                baseHealth += bonusHealth;
                _baseDmg += bonusDamage;
                Console.WriteLine($"You level up to Level {Level} gaining {bonusHealth} health and {bonusDamage} baseDamage");
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

        public void EquipWeapon(Weapon weapon)
        {
            _equipedWeapon = weapon;
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
            return Experience > (Level * 100);
        }

        public override int Attack<T>(T entity)
        {
            var dmg =  new Random().Next(_baseDmg, (_baseDmg + _equipedWeapon.damageBonus));
            entity.health -= dmg;
            return dmg;
        }
        

        public override string ToString()
        {
            return $"" +
                   $"Health: {health}/{baseHealth} Hp remaining\n" +
                   $"Currently equiped: {_equipedWeapon}\n" +
                   $"Currently Lvl: {Level}\n" +
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