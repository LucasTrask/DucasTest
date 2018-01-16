using System;
using System.Collections.Generic;
using System.Text;
using Decal.Adapter.Wrappers;

namespace DucasTest.Npcs
{
    class NpcFinder
    {

        public static int GetNpcId(string name)
        {
            WorldObjectCollection nearby_npcs = Globals.Core.WorldFilter.GetByObjectClass(ObjectClass.Npc);
            int npc_id = 0;
            foreach (WorldObject npc in nearby_npcs)
            {
                if (npc.Name.Equals(name))
                    return npc.Id;
            }
            return npc_id;
        }

        public static WorldObject GetNpc(string name)
        {
            WorldObjectCollection nearby_npcs = Globals.Core.WorldFilter.GetByObjectClass(ObjectClass.Npc);
            foreach (WorldObject npc in nearby_npcs)
            {
                if (npc.Name.Equals(name))
                    return npc;
            }
            return null;
        }


    }
}
