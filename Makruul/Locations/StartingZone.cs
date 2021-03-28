using System;
using System.Collections.Generic;

namespace Makruul
{
    public class StartingZone : INode
    {
        private Encounter initialEncounter;

        public StartingZone(Player player)
        {
            initialEncounter = new Encounter(player, new Wolf());
        }

        public bool IsDone()
        {
            return initialEncounter.IsDone();
        }

        public void Run()
        {
            EnterStartingZone();
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
                GameUtils.GetDelayedText(gameText, 1200);
            }
            
            initialEncounter.Run();

        }
    }
}