using System;
using System.Collections.Generic;
using Decal.Adapter.Wrappers;


namespace DucasTest.Npcs
{
    class AunMareuraTheCollector
    {
        // lists used by this class, only olthoi claws and vapor golem hearts supported at this time
        private static List<int> turnins = new List<int>();

        private static int AunMareura_ID;


        public static string TurnInHeartsAndClaws()
        {
            turnins.Clear();  // first clears lists from last time

            if ((AunMareura_ID = GenericFinderAndReturner.FindNpc("Aun Mareura the Collector")) == 0) // escape no NPC found
                return "Aun Mareura the Collector not found!";

            if (!GenerateItemLists())
            {
                Util.WriteToChat("No More Tumerok"); // this is to help Virindi views screen without pipes
                return "No Turn In Items Found!";
            }

            ActualTurnIn();

            return "No More Tumerok";
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
                    case "Olthoi Claw":
                    case "Vapor Golem Heart":
                        turnins.Add(item.Id);
                        break;
                }
            }

            return (turnins.Count > 0);

        }

        private static void ActualTurnIn()
        {
            while (0==0) // lol
            {
                Util.WriteToChat(turnins.Count.ToString() + " Items remaining to turn in!");

                for (int a = 0; a <= turnins.Count; a++)
                {
                    Globals.Core.Actions.GiveItem(turnins[a], AunMareura_ID);
                }

                if (!GenerateItemLists()) { return;}

                

                
            }
            

        }

    }
}
