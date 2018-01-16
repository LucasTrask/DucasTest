using System;
using System.Collections.Generic;
using System.Text;
using Decal.Adapter.Wrappers;
using DucasTest.Npcs;

namespace DucasTest.Npcs
{
    class WingCollector
    {
        private static int wingCollector_id = 0;
        private static List<int> wings = new List<int>();

        public static string TurnInWings()
        {
            wings.Clear();

            if ((wingCollector_id = GenericFinderAndReturner.FindNpc("Wing Collector")) == 0) // escape no NPC found
                return "Wing Collector not found!";

            if (!GenerateItemLists())
            {
                Util.WriteToChat("No More Wings"); // this is to help Virindi views screen without pipes
                return "No Turn In Items Found!";
            }

            ActualTurnIn();

            return "No More Wings";
        }

        private static void ActualTurnIn()
        {
            for (int a = 0; a <= wings.Count; a++)
            {
                Globals.Core.Actions.GiveItem(wings[a], wingCollector_id);
            }

        }


        private static Boolean GenerateItemLists()
        {

            WorldObjectCollection all_character_items_and_packs = Globals.Core.WorldFilter.GetByCategory(Globals.Core.CharacterFilter.Id);
            foreach (WorldObject item in all_character_items_and_packs) // cleaner looking
            {
                switch (item.Name)
                {
                    case "Jungle Phyntos Wasp Wing":
                        wings.Add(item.Id);
                        break;
                }
            }

            return (wings.Count > 0);

        }



    }
}
