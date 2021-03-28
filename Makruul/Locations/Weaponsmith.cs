using System;
using System.Collections.Generic;
using System.Linq;

namespace Makruul
{
    public class Weaponsmith : Establishment
    {
                
        private Dictionary<Weapon, int> _weapons;

        public Weaponsmith(Player player, string owner) : base(player, owner)
        {
            this.player = player;
            
            _weapons = new Dictionary<Weapon, int>(); _weapons = new Dictionary<Weapon, int>();
            Weapon ironDagger = new Weapon(15, "Iron dagger");
            Weapon ironShortsword = new Weapon(28, "Iron shortsword");
           
            _weapons[ironDagger] = 65;
            _weapons[ironShortsword] = 140;
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

        protected override void ShowGoods()
        {
            foreach(KeyValuePair<Weapon, int> entry in _weapons)
            {
                Console.WriteLine($"{entry.Key.name} ({entry.Key.damageBonus} Damage bonus) - {entry.Value} Goldcoins");
            }

            Console.WriteLine();
        }

        protected override void ConductBusiness(string itemName)
        {
            Weapon itemToBuy = _weapons.Keys.First((food => food.name == itemName));
            if(itemToBuy == null) return;
            if (_weapons[itemToBuy] > player.goldCoins) Console.WriteLine("You don't have enough Goldcoins to buy this\n");
            else
            {
                Console.WriteLine($"You sucessfully buy {itemToBuy.name} and equip it!\n");
                player.PayForItem(_weapons[itemToBuy]);
                player.AddWeapon(itemToBuy);
            }
        }

        protected override void GreetPlayer()
        {
            Console.WriteLine($"Hello there traveller, I'm {owner}, the town blacksmith!\nI assume you want to browse my weapons!\n");
        }
    }
}