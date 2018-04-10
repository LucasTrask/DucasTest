using System;
using System.Collections.Generic;
using Decal.Adapter.Wrappers;

namespace DucasTest.Npcs
{
    class IvoryCrafter
    {
        private static List<string> itemsToLookFor = new List<string> {
            "Dark Revenant Thighbone",
            "Lich Skull",
            "Sharp Tusker Slave Tusk",
            "Skeleton Skull",
            "Undead Thighbone",
            "Acid Axe",
            "Ice Tachi",
            "Usain Fang",
            "Niffis Pearl"};

        public static string TurnIn()
        {
            return GenericCollector.TurnInOneItem("Ivory Crafter", itemsToLookFor);
        }

    }
}
