using System;

namespace Makruul
{
    public abstract class Establishment : INode
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
            Console.WriteLine($"You currently have {player.goldCoins} Goldcoins");
            Console.WriteLine("So what do you wanna do?");
            Console.Write("Type either the name of the item you wish to buy or q to leave: ");
            var answer = Console.ReadLine();

            try
            {
                string properAnswer = answer;
                
                if (properAnswer == "q")
                {
                    _isDone = true;
                    Console.WriteLine($"You thank {owner} and leave the store");
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
    }
}