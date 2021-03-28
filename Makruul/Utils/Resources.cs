using System.Collections.Generic;

namespace Makruul
{
    public static class Resources
    {
        public static Weapon treeSword = new Weapon(5);



        public static Region hauntedVillage = new Region("Haunted Village");
        public static Region oldForrest = new Region("Old Forest");

        public static void AddRegions()
        {
            hauntedVillage.AddConnectedRegions(oldForrest);
            oldForrest.AddConnectedRegions(hauntedVillage);
            
        }
        
    }
}