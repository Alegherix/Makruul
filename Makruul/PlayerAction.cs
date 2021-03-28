using System;
using System.Collections.Generic;

namespace Makruul
{
    public class PlayerAction : INode
    {
        Player player;
        private Stack<INode> actionNodes;
        private bool _isDone;
        private Monster makruul;

        public PlayerAction(Player player, Stack<INode> actionNodes, Monster makruul)
        {
            this.player = player;
            this.actionNodes = actionNodes;
            this.makruul = makruul;

        }

        public bool IsDone()
        {
            return _isDone = true;
        }

        public void Run()
        {
            PerformTask(GetPlayerChoice());
        }

        public int GetPlayerChoice()
        {
            Console.WriteLine();
            GameUtils.GetDelayedText("What do you want to do now?");

            string[] playerOptions = player.GetOptions();
            List<string> allOptions = new List<string>(playerOptions);
            allOptions.Add("Search for more monsters to slay!");
            allOptions.Add(("I want to head into town!"));

            for (int i = 0; i < allOptions.Count; i++)
            {
                Console.WriteLine($"{i}) {allOptions[i]}");
            }
            Console.Write("Choice: ");
            return GameUtils.GetNumberInput();
        }

        public void PerformTask(int choice)
        {
            if(choice >= 0 && choice <=2) player.PerformOption(choice);
            else if (choice == 3)
            {
                if(player.Level >=6) actionNodes.Push(new Encounter(player, makruul));
                else actionNodes.Push(GameUtils.CreateRandomEncounter(player));
                _isDone = true;
            }
            else if (choice == 4)
            {
              actionNodes.Push(new Town("Svelinge", player));
              _isDone = true;
            }
        }
        
    }
}