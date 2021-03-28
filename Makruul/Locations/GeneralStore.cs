using System;
using System.Collections.Generic;
using System.Linq;

namespace Makruul
{
    public class GeneralStore : Establishment
    {

        private Dictionary<Weapon, int> _weapons;
        private Dictionary<Food, int> _foods;
        private bool _isDone;
        private Player player;

        public GeneralStore(Player player)
        {
            this.player = player;
            _weapons = new Dictionary<Weapon, int>(); _weapons = new Dictionary<Weapon, int>();
            Weapon ironDagger = new Weapon(15, "Iron dagger");
            Weapon ironShortsword = new Weapon(28, "Iron shortsword");
           
            _weapons[ironDagger] = 65;
            _weapons[ironShortsword] = 140;
            
            _foods = new Dictionary<Food, int>(); _foods = new Dictionary<Food, int>();
            Food cookedChicken = new Food("Cooked chicken", 45);
            Food steak = new Food("Tender steak", 90);
            
            _foods[cookedChicken] = 30;
            _foods[steak] = 50;
            
        }

        public override void VisitEstablishment()
        {
            ShowStore();
        }

        public override bool IsDone()
        {
            return _isDone;
        }

        public override void Run()
        {
            
            ShowStore();
        }

        private void ShowStore()
        {
            Console.WriteLine("Hello there traveller, welcome to my store\nI assume you want to browse my goods!\n");
            ShowGoods();
            GetPlayerAction();
            
        }

        private void ShowGoods()
        {
            foreach(KeyValuePair<Weapon, int> entry in _weapons)
            {
                Console.WriteLine($"{entry.Key.name} ({entry.Key.damageBonus} damage) - {entry.Value} Goldcoins");
            }
            
            foreach(KeyValuePair<Food, int> entry in _foods)
            {
                Console.WriteLine($"{entry.Key.name} ({entry.Key.healing} health regain when eaten) - {entry.Value} Goldcoins");
            }

            Console.WriteLine();

        }

        private void GetPlayerAction()
        {
            Console.WriteLine("So what do you wanna do?");
            Console.WriteLine("Type either the name of the goods you want to buy or q to leave");
            var answer = Console.ReadLine();

            try
            {
                string properAnswer = answer;
                
                if (properAnswer == "q")
                {
                    _isDone = true;
                    var doneText = IsDone() ? "Is done" : "Not done";
                    Console.WriteLine(doneText);
                }
                else
                {
                    BuyFood(properAnswer);
                }
                
                // BuyWeapon(properAnswer);
            }
            catch (Exception e)
            {
                Console.WriteLine("The Shopkeeper shakes his head in disappointment towards you");
                GetPlayerAction();
            }
            
        }

        void BuyFood(string itemName)
        {
            Food itemToBuy = _foods.Keys.First((food => food.name == itemName));
            if(itemToBuy == null) return;
            if (_foods[itemToBuy] > player.goldCoins) Console.WriteLine("You don't have enough goldcoins to buy this");
            else
            {
                Console.WriteLine($"You sucessfully buy {itemToBuy.name}");
                player.PayForItem(_foods[itemToBuy]);
                player.AddFood(itemToBuy);
            }
        }
        
        void BuyWeapon(string itemName)
        {
            Weapon itemToBuy = _weapons.Keys.First((weapon => weapon.name == itemName));
            if(itemToBuy == null) return;
            if (_weapons[itemToBuy] > player.goldCoins) Console.WriteLine("You don't have enough goldcoins to buy this");
            else
            {
                Console.WriteLine($"You sucessfully buy {itemToBuy.name} and equip it");
                player.PayForItem(_weapons[itemToBuy]);
                player.AddWeapon(itemToBuy);
            }
        }
    }
}