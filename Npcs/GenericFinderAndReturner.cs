using System;
using System.Collections.Generic;
using System.Text;
using Decal.Adapter.Wrappers;
using DucasTest.Npcs;

namespace DucasTest.Npcs
{
    class GenericFinderAndReturner
    {
        public static int FindNpc(string name)
        {
            WorldObject wingCollector = NpcFinder.GetNpc(name);
            if (null == wingCollector) { return 0; }
            return wingCollector.Id;
        }


    }
}
