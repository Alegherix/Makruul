using System;
using System.Collections.Generic;
using System.Threading;

namespace Makruul
{
    public class Game : INode
    {
        private Player player;
        private Stack<INode> actionNodes;
        private Monster makruul;

        void ShowIntroText()
        {
            Console.WriteLine("          _____                    _____                    _____                    _____                    _____                    _____                    _____  \n         /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\ \n        /::\\____\\                /::\\    \\                /::\\____\\                /::\\    \\                /::\\____\\                /::\\____\\                /::\\____\\\n       /::::|   |               /::::\\    \\              /:::/    /               /::::\\    \\              /:::/    /               /:::/    /               /:::/    /\n      /:::::|   |              /::::::\\    \\            /:::/    /               /::::::\\    \\            /:::/    /               /:::/    /               /:::/    / \n     /::::::|   |             /:::/\\:::\\    \\          /:::/    /               /:::/\\:::\\    \\          /:::/    /               /:::/    /               /:::/    /  \n    /:::/|::|   |            /:::/__\\:::\\    \\        /:::/____/               /:::/__\\:::\\    \\        /:::/    /               /:::/    /               /:::/    /   \n   /:::/ |::|   |           /::::\\   \\:::\\    \\      /::::\\    \\              /::::\\   \\:::\\    \\      /:::/    /               /:::/    /               /:::/    /    \n  /:::/  |::|___|______    /::::::\\   \\:::\\    \\    /::::::\\____\\________    /::::::\\   \\:::\\    \\    /:::/    /      _____    /:::/    /      _____    /:::/    /     \n /:::/   |::::::::\\    \\  /:::/\\:::\\   \\:::\\    \\  /:::/\\:::::::::::\\    \\  /:::/\\:::\\   \\:::\\____\\  /:::/____/      /\\    \\  /:::/____/      /\\    \\  /:::/    /      \n/:::/    |:::::::::\\____\\/:::/  \\:::\\   \\:::\\____\\/:::/  |:::::::::::\\____\\/:::/  \\:::\\   \\:::|    ||:::|    /      /::\\____\\|:::|    /      /::\\____\\/:::/____/       \n\\::/    / ~~~~~/:::/    /\\::/    \\:::\\  /:::/    /\\::/   |::|~~~|~~~~~     \\::/   |::::\\  /:::|____||:::|____\\     /:::/    /|:::|____\\     /:::/    /\\:::\\    \\       \n \\/____/      /:::/    /  \\/____/ \\:::\\/:::/    /  \\/____|::|   |           \\/____|:::::\\/:::/    /  \\:::\\    \\   /:::/    /  \\:::\\    \\   /:::/    /  \\:::\\    \\      \n             /:::/    /            \\::::::/    /         |::|   |                 |:::::::::/    /    \\:::\\    \\ /:::/    /    \\:::\\    \\ /:::/    /    \\:::\\    \\     \n            /:::/    /              \\::::/    /          |::|   |                 |::|\\::::/    /      \\:::\\    /:::/    /      \\:::\\    /:::/    /      \\:::\\    \\    \n           /:::/    /               /:::/    /           |::|   |                 |::| \\::/____/        \\:::\\__/:::/    /        \\:::\\__/:::/    /        \\:::\\    \\   \n          /:::/    /               /:::/    /            |::|   |                 |::|  ~|               \\::::::::/    /          \\::::::::/    /          \\:::\\    \\  \n         /:::/    /               /:::/    /             |::|   |                 |::|   |                \\::::::/    /            \\::::::/    /            \\:::\\    \\ \n        /:::/    /               /:::/    /              \\::|   |                 \\::|   |                 \\::::/    /              \\::::/    /              \\:::\\____\\\n        \\::/    /                \\::/    /                \\:|   |                  \\:|   |                  \\::/____/                \\::/____/                \\::/    /\n         \\/____/                  \\/____/                  \\|___|                   \\|___|                   ~~                       ~~                       \\/____/ \n                                                                                                                                                                       ");
        }
        
        void SetupCharacter()
        {
            
            Console.Write("Input the name of your character: ");
            var chosenName = Console.ReadLine();
            player = new Player(chosenName);
            
            GameUtils.GetDelayedText($"A fitting name for a warrior, {player.name}", 1200);
            GameUtils.GetDelayedText("Good luck on your adventure young traveller", 1200);
            GameUtils.GetDelayedText("and so the journey begins....", 1200);
            GameUtils.GetDelayedText("\n\n\n\n", 1200);
        }

        public void TellStoryTask()
        {
            GameUtils.GetDelayedText("Your task is to find Makruul the gruesome, a hideous werewolf that's been ravaging the lands", 800);
            GameUtils.GetDelayedText("The last time he was spotted was close to cave", 1200);
        }
        public void StartGame()
        {
            actionNodes = new Stack<INode>();
            ShowIntroText();
            SetupCharacter();
          
            actionNodes.Push(new StartingZone(player));
            makruul = new Makruul();
            TellStoryTask();
            Run();
        }

        public bool IsDone()
        {
            return makruul.health <= 0;
        }

        public void Run()
        {
            // Make progress until Level 5, then face of with Makruul,
            while (makruul.health >0)
            {
                if (actionNodes.Count > 0) actionNodes.Pop().Run();
                else actionNodes.Push(new PlayerAction(player, actionNodes, makruul));
            }

            Console.WriteLine("Congratulations, You slayed Makruuel the gruesome and saved Svelinge, that's pretty cool of u!");
        }
    }
}