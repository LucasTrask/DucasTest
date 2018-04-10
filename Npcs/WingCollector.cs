using System;
using System.Collections.Generic;
using System.Text;
using Decal.Adapter.Wrappers;
using DucasTest.Npcs;

namespace DucasTest.Npcs
{
    class WingCollector
    {
        private static List<string> itemsToLookFor = new List<string> { "Jungle Phyntos Wasp Wing", "White Phyntos Wasp Wing" };

        public static string TurnIn()
        {
            return GenericCollector.TurnInOneItem("Wing Collector", itemsToLookFor);
        }
    }
}
