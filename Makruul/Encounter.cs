using System;
using System.Threading;

namespace Makruul
{
    public class Encounter : INode
    {
        private Player player;
        private bool _isDone;
        private Monster monster;


        public Encounter(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
        }

        public bool IsDone()
        {
            return _isDone;
        }

        public void Run()
        {
            DecideAction(GetPlayerFightResponse(), () => InitiateFight(player, monster), () => FleeTheScene());
        }
        
        public bool GetPlayerFightResponse()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1) I laugh in the face of danger, I want to kill whatever it might be");
            Console.WriteLine("2) I'm a feeling a little off about this one, time to flee");
            Console.Write("1/2?: ");
            if (!int.TryParse(Console.ReadLine(), out var answer))
            {
                Console.WriteLine("You have to type either 1 or 2!");
                GetPlayerFightResponse();
            }
            Console.WriteLine("\n");
            return answer == 1;
        }
        
        public void InitiateFight(Player player, Monster monster)
        {
            while (monster.health > 0 || player.health > 0)
            {
                var playerDmg = player.Attack(monster);
                var playerOutput = (monster.health <= 0)
                    ? ($"With a quick blow {player.name} strikes {monster.name}, finally killing it")
                    : ($"{player.name} swings his sword towards {monster.name}, striking {playerDmg} damage");
                Console.WriteLine(playerOutput);
                

                if (monster.health > 0)
                {
                    var monsterDmg = monster.Attack(player);
                    Console.WriteLine($"{monster.name} stumbles and attacks {player.name}, hitting him for {monsterDmg} damage");
                }
                Console.WriteLine("\n");
                
                Thread.Sleep(300);

                if (player.health <= 0)
                {
                    
                    Console.WriteLine("You died....");
                    System.Environment.Exit(1);
                }
                else if (monster.health <= 0)
                {
                    Console.WriteLine($"You slayed the ferocious beast and gained {monster.ExperienceGiven} experience" );
                    player.GainExperience(monster.ExperienceGiven);
                    _isDone = true;
                    break;
                }
            }
        }
        
        private void FleeTheScene(){
            Console.WriteLine("You take of running for your dear life, it might have been the best choice, and it might not, you'll never know now...");
        }

        private void DecideAction(bool wantAction, Action firstChoice, Action secondChoice)
        {
            if (wantAction) firstChoice();
            else secondChoice();
        }
        
    }
}