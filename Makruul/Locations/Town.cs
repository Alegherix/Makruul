using System.Collections.Generic;

namespace Makruul
{
    public class Town : INode
    {
        public string name;
        public List<Establishment> establishments;
        private Player _player;

        public Town(string name, Player player)
        {
            this.name = name;
            GeneralStore generalStore = new GeneralStore(player, "Methram");
            Weaponsmith weaponsmith = new Weaponsmith(player, "Zackari");

            establishments = new List<Establishment>();
            establishments.Add(generalStore);
            establishments.Add(weaponsmith);
        }

        public bool IsDone()
        {
            throw new System.NotImplementedException();
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
        
    }
}