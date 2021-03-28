using System;
using System.Collections.Generic;
using System.Threading;

namespace Makruul
{
    public class Game : INode
    {
        private Player player;
        private Stack<INode> actionNodes;
        private Encounter bossEncounter;
        
        void ShowIntroText()
        {
            Console.WriteLine("          _____                    _____                    _____                    _____                    _____                    _____                    _____  \n         /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\ \n        /::\\____\\                /::\\    \\                /::\\____\\                /::\\    \\                /::\\____\\                /::\\____\\                /::\\____\\\n       /::::|   |               /::::\\    \\              /:::/    /               /::::\\    \\              /:::/    /               /:::/    /               /:::/    /\n      /:::::|   |              /::::::\\    \\            /:::/    /               /::::::\\    \\            /:::/    /               /:::/    /               /:::/    / \n     /::::::|   |             /:::/\\:::\\    \\          /:::/    /               /:::/\\:::\\    \\          /:::/    /               /:::/    /               /:::/    /  \n    /:::/|::|   |            /:::/__\\:::\\    \\        /:::/____/               /:::/__\\:::\\    \\        /:::/    /               /:::/    /               /:::/    /   \n   /:::/ |::|   |           /::::\\   \\:::\\    \\      /::::\\    \\              /::::\\   \\:::\\    \\      /:::/    /               /:::/    /               /:::/    /    \n  /:::/  |::|___|______    /::::::\\   \\:::\\    \\    /::::::\\____\\________    /::::::\\   \\:::\\    \\    /:::/    /      _____    /:::/    /      _____    /:::/    /     \n /:::/   |::::::::\\    \\  /:::/\\:::\\   \\:::\\    \\  /:::/\\:::::::::::\\    \\  /:::/\\:::\\   \\:::\\____\\  /:::/____/      /\\    \\  /:::/____/      /\\    \\  /:::/    /      \n/:::/    |:::::::::\\____\\/:::/  \\:::\\   \\:::\\____\\/:::/  |:::::::::::\\____\\/:::/  \\:::\\   \\:::|    ||:::|    /      /::\\____\\|:::|    /      /::\\____\\/:::/____/       \n\\::/    / ~~~~~/:::/    /\\::/    \\:::\\  /:::/    /\\::/   |::|~~~|~~~~~     \\::/   |::::\\  /:::|____||:::|____\\     /:::/    /|:::|____\\     /:::/    /\\:::\\    \\       \n \\/____/      /:::/    /  \\/____/ \\:::\\/:::/    /  \\/____|::|   |           \\/____|:::::\\/:::/    /  \\:::\\    \\   /:::/    /  \\:::\\    \\   /:::/    /  \\:::\\    \\      \n             /:::/    /            \\::::::/    /         |::|   |                 |:::::::::/    /    \\:::\\    \\ /:::/    /    \\:::\\    \\ /:::/    /    \\:::\\    \\     \n            /:::/    /              \\::::/    /          |::|   |                 |::|\\::::/    /      \\:::\\    /:::/    /      \\:::\\    /:::/    /      \\:::\\    \\    \n           /:::/    /               /:::/    /           |::|   |                 |::| \\::/____/        \\:::\\__/:::/    /        \\:::\\__/:::/    /        \\:::\\    \\   \n          /:::/    /               /:::/    /            |::|   |                 |::|  ~|               \\::::::::/    /          \\::::::::/    /          \\:::\\    \\  \n         /:::/    /               /:::/    /             |::|   |                 |::|   |                \\::::::/    /            \\::::::/    /            \\:::\\    \\ \n        /:::/    /               /:::/    /              \\::|   |                 \\::|   |                 \\::::/    /              \\::::/    /              \\:::\\____\\\n        \\::/    /                \\::/    /                \\:|   |                  \\:|   |                  \\::/____/                \\::/____/                \\::/    /\n         \\/____/                  \\/____/                  \\|___|                   \\|___|                   ~~                       ~~                       \\/____/ \n                                                                                                                                                                       ");
        }
        
        void SetupCharacter()
        {
            
            // Console.Write("Input the name of your character: ");
            // var chosenName = Console.ReadLine();
            // player = new Player(chosenName);
            
            // GameUtils.GetDelayedText($"A fitting name for a warrior, {player.name}", 1200);
            // GameUtils.GetDelayedText("Good luck on your adventure young traveller", 1200);
            // GameUtils.GetDelayedText("and so the journey begins....", 1200);
            // GameUtils.GetDelayedText("\n\n\n\n", 1200);

            player = new Player("Alegherix");
        }

        public void TellStoryTask()
        {
            GameUtils.GetDelayedText("Your task is to find Makruul the gruesome, a hideous werewolf that's been ravaging the lands", 800);
            GameUtils.GetDelayedText("The last time he was spotted was close to cave", 1200);
        }
        public void StartGame()
        {
             bossEncounter = new Encounter(player, new Makruul());
            // ShowIntroText();
            SetupCharacter();
            actionNodes = new Stack<INode>();
            // actionNodes.Push(new StartingZone(player));
            actionNodes.Push(new PlayerAction(player, actionNodes));
            // actionNodes.Push(new Town("Svelinge", player));
            // TellStoryTask();
            Run();
        }

        public bool IsDone()
        {
            return bossEncounter.IsDone();
        }

        public void Run()
        {
            // Make progress until Level 5, then face of with Makruul,
            
            while (player._level <6)
            {
                if (actionNodes.Count > 0) actionNodes.Pop().Run();
                else actionNodes.Push(new PlayerAction(player, actionNodes));
            }
            
            bossEncounter.Run();
            
        }
    }
}