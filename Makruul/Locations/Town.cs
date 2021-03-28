using System;
using System.Collections.Generic;
using System.Linq;

namespace Makruul
{
    public class Town : INode
    {
        public string name;
        public List<Establishment> establishments;
        private Player player;
        private bool _isDone;
        private List<IOption> _options;

        public Town(string name, Player player)
        {
            this.player = player;
            this.name = name;
            GeneralStore generalStore = new GeneralStore(player, "Methram");
            Weaponsmith weaponsmith = new Weaponsmith(player, "Zackari");

            establishments = new List<Establishment>();
            establishments.Add(generalStore);
            establishments.Add(weaponsmith);

            _options = new List<IOption>();
            _options.Add(player);
            _options.Add(generalStore);
            _options.Add(weaponsmith);
            
        }

        public bool IsDone()
        {
            return _isDone;
        }

        public void Run()
        {
            EnterTown();
            while (!IsDone())
            {
               FetchAction();
            }
        }

        public void EnterTown()
        {
            Console.WriteLine($"You feel weary eyes watching your back as you make your way into the center of {name}");
            
        }

        public void FetchAction()
        {
            Console.WriteLine("What do you want to do?");
            performChoice(GetPlayerChoice());
        }
        

        public int GetPlayerChoice()
        {

            // Ghetto solution 
            var allPlayerOptions = player.GetOptions();
            var allBlackSmithOptions = _options[1].GetOptions();
            var allWeaponSmithOptions = _options[2].GetOptions();

            var options = new string[6];
            options[0] = allPlayerOptions[0];
            options[1] = allPlayerOptions[1];
            options[2] = allPlayerOptions[2];
            options[3] = allBlackSmithOptions[0];
            options[4] = allWeaponSmithOptions[0];
            options[5] = "Leave town";

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i}) {options[i]}");
            }

            Console.Write("Enter the number of the action you want to take: ");
            return GameUtils.GetNumberInput();

        }

        public void performChoice(int choice)
        {
            
            if(choice <=2) player.PerformOption(choice);
            else if(choice == 3) establishments[0].PerformOption();
            else if(choice == 4) establishments[1].PerformOption();
            else
            {
                Console.WriteLine($"You leave {name} in the opposite way in which you came!");
                _isDone = true;
            }
            
        }
        
    }
}