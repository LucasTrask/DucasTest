using System;
using System.Collections.Generic;
using Decal.Adapter.Wrappers;
using System.Text;

namespace DucasTest.Npcs
{
    class GenericCollector
    {
        private static int npc_id = 0;
        private static List<int> turnins = new List<int>();

        public static string TurnInOneItem(string npcName, List<string> itemsThatCanBeTurnedIn)
        {
            turnins.Clear();

            if ((npc_id = GenericFinderAndReturner.FindNpc(npcName)) == 0) // escape no NPC found
                return npcName + " not found!";

            if (!GenerateItemLists(itemsThatCanBeTurnedIn))
            {
                Util.WriteToChat("No more items to turn in"); // this is to help Virindi views screen without pipes
                return "No Turn In Items Found!";
            }

            ActualTurnIn();

            return "No more items to turn in";
        }

        private static Boolean GenerateItemLists(List<string> itemsThatCanBeTurnedIn)
        {

            WorldObjectCollection all_character_items_and_packs = Globals.Core.WorldFilter.GetByCategory(Globals.Core.CharacterFilter.Id);
            foreach (WorldObject item in all_character_items_and_packs) // cleaner looking
            {
                if (itemsThatCanBeTurnedIn.Contains(item.Name))
                {
                    turnins.Add(item.Id);
                }
            }

            return (turnins.Count > 0);
        }

        private static void ActualTurnIn()
        {
            if (turnins.Count > 0)
            {
                Globals.Core.Actions.GiveItem(turnins[0], npc_id);
            }

        }




    }
}
