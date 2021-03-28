using System;
using System.Collections.Generic;
using System.Threading;

namespace Makruul
{
    public static class GameUtils
    {

        public static void GetDelayedText(string text, int delay = 400)
        {
            Console.WriteLine(text);
            Thread.Sleep(delay);
        }

        public static int GetNumberInput()
        {
            string l = Console.ReadLine();
            int choice = 0;

            while(!int.TryParse(l, out choice))
            {
                Console.WriteLine("Only enter a number");
                l = Console.ReadLine();
            }

            Console.WriteLine();
            return choice;
        }

        public static Encounter CreateRandomEncounter(Player player)
        {
            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Wolf());
            monsters.Add(new Ghoul());
            monsters.Add(new Dragon());
            monsters.Add(new Basilisk());
            int randomVal =  new Random().Next(monsters.Count);
            return new Encounter(player, monsters[randomVal]);
        }
    }
}