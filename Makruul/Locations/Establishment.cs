using System;

namespace Makruul
{
    public abstract class Establishment : INode, IOption
    {
        
        private bool _isDone;
        protected Player player;
        protected string owner;

        protected Establishment(Player player, string owner)
        {
            this.player = player;
            this.owner = owner;
        }

        public bool IsDone()
        {
            return _isDone;
        }
        public void Run()
        {
            VisitEstablishment();
        }

        protected abstract void ShowGoods();
        protected abstract void ConductBusiness(string itemName);

        protected abstract void GreetPlayer();
        
        public void VisitEstablishment()
        {
            GreetPlayer();
            ShowGoods();
            while(!IsDone()) GetPlayerAction();
        }
        
        private void GetPlayerAction()
        {
            GameUtils.GetDelayedText($"You currently have {player.goldCoins} Goldcoins");
            GameUtils.GetDelayedText("So what do you wanna do?");
            Console.Write("Type either the name of the item you wish to buy or q to leave: ");
            var answer = Console.ReadLine();

            try
            {
                string properAnswer = answer;
                
                if (properAnswer == "q")
                {
                    _isDone = true;
                    Console.WriteLine($"You thank {owner} and leave the store \n");
                }
                else
                {
                    ConductBusiness(properAnswer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The Shopkeeper shakes his head in disappointment towards you\n");
                GetPlayerAction();
            }
        }

        public string[] GetOptions()
        {
            return new[] {$"Visit the {this.GetType().Name}"};
        }

        public void PerformOption(int option = 0)
        {
            // Reset flag in case we wanna revisit shop, so we don't need to reinit objects.
            if (_isDone) _isDone = false;
            Run();
        }
    }
}