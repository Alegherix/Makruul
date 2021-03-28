using System;
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
    }
}