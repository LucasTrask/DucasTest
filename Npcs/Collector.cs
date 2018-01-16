using System;
using System.Collections.Generic;
using Decal.Adapter.Wrappers;

namespace DucasTest.Npcs
{
    class Collector
    {
        private static int collector_id = 0;
        private static List<int> turnins = new List<int>();

        public static string TurnInStuff()
        {
            turnins.Clear();

            if ((collector_id = GenericFinderAndReturner.FindNpc("Collector")) == 0) // escape no NPC found
                return "Collector not found!";

            if (!GenerateItemLists())
            {
                Util.WriteToChat("No More Collector"); // this is to help Virindi views screen without pipes
                return "No Turn In Items Found!";
            }

            ActualTurnIn();

            return "No More Collector";
        }

        private static void ActualTurnIn()
        {
            for (int a = 0; a <= turnins.Count; a++)
            {
                Globals.Core.Actions.GiveItem(turnins[a], collector_id);
            }

        }


        private static Boolean GenerateItemLists()
        {

            WorldObjectCollection all_character_items_and_packs = Globals.Core.WorldFilter.GetByCategory(Globals.Core.CharacterFilter.Id);
            foreach (WorldObject item in all_character_items_and_packs) // cleaner looking
            { // i should hard code a list of everything the Collector can accept aad compare instead of switch
                switch (item.Name) 
                {
                    case "Seal":
                    case "Shendolain Key":
                    case "Large Lugian Sinew":
                        turnins.Add(item.Id);
                        break;
                }
            }

            return (turnins.Count > 0);

        }


    }
}
