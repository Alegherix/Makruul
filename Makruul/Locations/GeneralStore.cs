using System;
using System.Collections.Generic;
using System.Linq;

namespace Makruul
{
    public class GeneralStore : Establishment
    {
        
        private Dictionary<Food, int> _foods;

        public GeneralStore(Player player, string owner) : base(player, owner)
         {
             _foods = new Dictionary<Food, int>(); _foods = new Dictionary<Food, int>();
            Food cookedChicken = new Food("Cooked chicken", 45);
            Food porkChops = new Food("Pork chops", 65);
            Food steak = new Food("Tender steak", 90);
           
            
            _foods[cookedChicken] = 30;
            _foods[porkChops] = 45;
            _foods[steak] = 65;
         }
        
        
        protected override void ShowGoods()
        {
            foreach(KeyValuePair<Food, int> entry in _foods)
            {
                Console.WriteLine($"{entry.Key.name} ({entry.Key.healing} health regeneration) - {entry.Value} Goldcoins");
            }

            Console.WriteLine();
        }

        protected override void ConductBusiness(string itemName)
        {
            Food itemToBuy = _foods.Keys.First((food => food.name == itemName));
            if(itemToBuy == null) return;
            if (_foods[itemToBuy] > player.goldCoins) Console.WriteLine("You don't have enough Goldcoins to buy this\n");
            else
            {
                Console.WriteLine($"You sucessfully buy {itemToBuy.name}\n");
                player.PayForItem(_foods[itemToBuy]);
                player.AddFood(itemToBuy);
            }
        }

        protected override void GreetPlayer()
        {
            GameUtils.GetDelayedText($"\nHello there traveller, I'm {owner} welcome to my store", 600);
            GameUtils.GetDelayedText("I assume you want to browse my goods!\n");
        }

    }
}