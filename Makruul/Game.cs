using System;
using System.Collections.Generic;
using System.Threading;

namespace Makruul
{
    public class Game
    {
        private Player player;

        void ShowIntroText()
        {
            Console.WriteLine("          _____                    _____                    _____                    _____                    _____                    _____                    _____  \n         /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\ \n        /::\\____\\                /::\\    \\                /::\\____\\                /::\\    \\                /::\\____\\                /::\\____\\                /::\\____\\\n       /::::|   |               /::::\\    \\              /:::/    /               /::::\\    \\              /:::/    /               /:::/    /               /:::/    /\n      /:::::|   |              /::::::\\    \\            /:::/    /               /::::::\\    \\            /:::/    /               /:::/    /               /:::/    / \n     /::::::|   |             /:::/\\:::\\    \\          /:::/    /               /:::/\\:::\\    \\          /:::/    /               /:::/    /               /:::/    /  \n    /:::/|::|   |            /:::/__\\:::\\    \\        /:::/____/               /:::/__\\:::\\    \\        /:::/    /               /:::/    /               /:::/    /   \n   /:::/ |::|   |           /::::\\   \\:::\\    \\      /::::\\    \\              /::::\\   \\:::\\    \\      /:::/    /               /:::/    /               /:::/    /    \n  /:::/  |::|___|______    /::::::\\   \\:::\\    \\    /::::::\\____\\________    /::::::\\   \\:::\\    \\    /:::/    /      _____    /:::/    /      _____    /:::/    /     \n /:::/   |::::::::\\    \\  /:::/\\:::\\   \\:::\\    \\  /:::/\\:::::::::::\\    \\  /:::/\\:::\\   \\:::\\____\\  /:::/____/      /\\    \\  /:::/____/      /\\    \\  /:::/    /      \n/:::/    |:::::::::\\____\\/:::/  \\:::\\   \\:::\\____\\/:::/  |:::::::::::\\____\\/:::/  \\:::\\   \\:::|    ||:::|    /      /::\\____\\|:::|    /      /::\\____\\/:::/____/       \n\\::/    / ~~~~~/:::/    /\\::/    \\:::\\  /:::/    /\\::/   |::|~~~|~~~~~     \\::/   |::::\\  /:::|____||:::|____\\     /:::/    /|:::|____\\     /:::/    /\\:::\\    \\       \n \\/____/      /:::/    /  \\/____/ \\:::\\/:::/    /  \\/____|::|   |           \\/____|:::::\\/:::/    /  \\:::\\    \\   /:::/    /  \\:::\\    \\   /:::/    /  \\:::\\    \\      \n             /:::/    /            \\::::::/    /         |::|   |                 |:::::::::/    /    \\:::\\    \\ /:::/    /    \\:::\\    \\ /:::/    /    \\:::\\    \\     \n            /:::/    /              \\::::/    /          |::|   |                 |::|\\::::/    /      \\:::\\    /:::/    /      \\:::\\    /:::/    /      \\:::\\    \\    \n           /:::/    /               /:::/    /           |::|   |                 |::| \\::/____/        \\:::\\__/:::/    /        \\:::\\__/:::/    /        \\:::\\    \\   \n          /:::/    /               /:::/    /            |::|   |                 |::|  ~|               \\::::::::/    /          \\::::::::/    /          \\:::\\    \\  \n         /:::/    /               /:::/    /             |::|   |                 |::|   |                \\::::::/    /            \\::::::/    /            \\:::\\    \\ \n        /:::/    /               /:::/    /              \\::|   |                 \\::|   |                 \\::::/    /              \\::::/    /              \\:::\\____\\\n        \\::/    /                \\::/    /                \\:|   |                  \\:|   |                  \\::/____/                \\::/____/                \\::/    /\n         \\/____/                  \\/____/                  \\|___|                   \\|___|                   ~~                       ~~                       \\/____/ \n                                                                                                                                                                       ");
        }
        
        void SetupCharacter()
        {
            
            Console.Write("Input the name of your character: ");
            var chosenName = Console.ReadLine();
            player = new Player(chosenName);

            GeneralStore generalStore = new GeneralStore(player);
            
            generalStore.Run();


            // GetDelayedText($"A fitting name for a warrior, {player.name}", 1200);
            // GetDelayedText("Good luck on your adventure young traveller", 1200);
            // GetDelayedText("and so the journey begins....", 1200);
            // GetDelayedText("\n\n\n\n", 1200);


        }

        public void StartGame()
        {
            Resources.AddRegions();
            // ShowIntroText();
            SetupCharacter();
            // EnterStartingZone();
        }

        private void GetDelayedText(string text, int delay)
        {
            Console.WriteLine(text);
            Thread.Sleep(delay);
        }
        
        
        public void EnterStartingZone()
        {
            List<string> gameTexts = new List<string>(){
                "You find yourself wandering aimlessly in a dark forest", 
                "You let your eyes wonder freely trying to make out something of resemblance",
                "You hear a muffled roar coming from some bushes just behind some cow parsley.",
            };

            foreach (var gameText in gameTexts)
            {
                GetDelayedText(gameText, 1200);
            }
            Encounter initialEncounter = new Encounter(player, new Wolf());
            initialEncounter.Run();
            
            
           
        }
        
        
        
        
    
    }
}