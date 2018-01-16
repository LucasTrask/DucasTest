using System;
using System.Collections.Generic;
using Decal.Adapter.Wrappers;

namespace DucasTest.Npcs
{
    class RenselmsApprentice
    {

        // lists used by this class, only olthoi claws and vapor golem hearts supported at this time
        private static List<int> turnins = new List<int>();

        private static int RenselmsApprentice_id;


        public static string TurnInTriangles()
        {
            turnins.Clear();  // first clears lists from last time

            if ((RenselmsApprentice_id = GenericFinderAndReturner.FindNpc("Renselm's Apprentice")) == 0) // escape no NPC found
                return "Renselm's Apprentice!";

            if (!GenerateItemLists())
            {
                Util.WriteToChat("No More Triangles"); // this is to help Virindi views screen without pipes
                return "No Turn In Items Found!";
            }

            ActualTurnIn();

            return "No More Triangles";
        }



        /**
         * Returns a false if it can't find this NPC
         * For now it prints out all NPCs discovered
         */
        private static Boolean FindRenselmsApprentice()
        {
            WorldObject iCollector = NpcFinder.GetNpc("Renselm's Apprentice");
            if (null == iCollector) { return false; }
            RenselmsApprentice_id = iCollector.Id;
            return true;
        }

        /**
         * Returns a false if no matching items found, otherwise adds item ids to respective lists
         */
        private static Boolean GenerateItemLists()
        {
            turnins.Clear();
            WorldObjectCollection all_character_items_and_packs = Globals.Core.WorldFilter.GetByCategory(Globals.Core.CharacterFilter.Id);
            foreach (WorldObject item in all_character_items_and_packs) // cleaner looking
            {
                switch (item.Name)
                {
                    case "A Large Mnemosyne":
                    case "An Unlocked Large Mnemosyne":
                        turnins.Add(item.Id);
                        break;
                }
            }

            return (turnins.Count > 0);

        }

        private static void ActualTurnIn()
        {
            while (0 == 0) // lol
            {
                Util.WriteToChat(turnins.Count.ToString() + " Items remaining to turn in!");

                for (int a = 0; a <= turnins.Count; a++)
                {
                    Globals.Core.Actions.GiveItem(turnins[a], RenselmsApprentice_id);
                }

                if (!GenerateItemLists()) { return; }

            }
        }
    }
}
