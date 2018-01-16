using System;
using System.Collections.Generic;
using Decal.Adapter.Wrappers;

namespace DucasTest.Npcs
{
    class IvoryCrafter
    {

        // lists used by this class, only olthoi claws and vapor golem hearts supported at this time
        private static List<int> turnins = new List<int>();

        private static int IvoryCrafter_ID;


        public static string TurnInIvory()
        {
            turnins.Clear();  // first clears lists from last time

            if ((IvoryCrafter_ID = GenericFinderAndReturner.FindNpc("Ivory Crafter")) == 0) // escape no NPC found
                return "Ivory Crafter not found!";

            if (!GenerateItemLists())
            {
                Util.WriteToChat("No More Ivory"); // this is to help Virindi views screen without pipes
                return "No Turn In Items Found!";
            }

            return ActualTurnIn();
        }



        /**
         * Returns a false if it can't find this NPC
         * For now it prints out all NPCs discovered
         */
        private static Boolean FindIvoryCrafter()
        {
            WorldObject iCollector = NpcFinder.GetNpc("Ivory Crafter");
            if (null == iCollector) { return false; }
            IvoryCrafter_ID = iCollector.Id;
            return true;
        }

        /**
         * Returns a false if no matching items found, otherwise adds item ids to respective lists
         */
        public static Boolean GenerateItemLists()
        {
            turnins.Clear();
            WorldObjectCollection all_character_items_and_packs = Globals.Core.WorldFilter.GetByCategory(Globals.Core.CharacterFilter.Id);
            foreach (WorldObject item in all_character_items_and_packs) // cleaner looking
            {
                switch (item.Name)
                {
                    case "Dark Revenant Thighbone":
                    case "Lich Skull":
                    case "Sharp Tusker Slave Tusk":
                    case "Skeleton Skull":
                    case "Undead Thighbone":
                    case "Acid Axe":
                    case "Ice Tachi":
                    case "Usain Fang":
                    case "Niffis Pearl":
                        turnins.Add(item.Id);
                        break;
                }
            }

            return (turnins.Count > 0);

        }

        private static String ActualTurnIn()
        {
            if (turnins.Count == 0) { return "No More Ivory"; }
            if (turnins.Count > 1)
            {
                Globals.Core.Actions.GiveItem(turnins[0], IvoryCrafter_ID);
                GenerateItemLists();
                return (turnins.Count - 1).ToString() + " items remaining!";
            }
            if (turnins.Count == 1)
            {
                Globals.Core.Actions.GiveItem(turnins[0], IvoryCrafter_ID);
                return "No More Ivory"; 
            }

            return "Error in Ivory Turn-in Method!";

        }
    }
}
