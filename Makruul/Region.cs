using System;
using System.Collections.Generic;

namespace Makruul
{
    public class Region
    {
        private string _name;
        private List<Region> _connectedRegions;


        public Region(string name)
        {
            _name = name;
            _connectedRegions = new List<Region>();

        }

        public void AddConnectedRegions(Region connectedRegion)
        {
            _connectedRegions.Add(connectedRegion);
        }
    }
}