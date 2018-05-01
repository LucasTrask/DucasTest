using Decal.Adapter.Wrappers;
using DucasTest.ItemEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DucasTest.Inventory
{
    class CombineSalvage
    {
        private static List<String> salvageTypesToCombine = new List<string>();

        public static string Combine()
        {
            //addTypes();
            MultiMap<int> inventoryDictionary = BuildInventoryMap.FromInventory(salvageTypesToCombine);
            int ustId = 0;
            foreach (WorldObject item in Globals.Core.WorldFilter.GetByContainer(Globals.Core.CharacterFilter.Id))
            {
                if (item.Name.Equals("Ust"))
                {
                    ustId = item.Id;
                }
            }

            if (ustId == 0)
            {
                return "Ust not found in Main Pack!";
            }

            int keys = 0;
            int combinations = 0;

            foreach (String a in inventoryDictionary.Keys)
            {
                int values = 0;
                keys++;
                Globals.Core.Actions.UseItem(ustId, 1);
                foreach (int b in inventoryDictionary[a])
                {
                    Globals.Core.Actions.SalvagePanelAdd(b);
                    values++;
                }
                if (values > 0)
                {
                    Globals.Core.Actions.SalvagePanelSalvage();
                }
                if (values > 1)
                {
                    //Util.WriteToChat(values.ToString() + " bags of " + a + " combined!", ChatUtil.Color.grey); // need to convert from ID to name
                    combinations++;
                }
            }

            return keys.ToString() + " types of salvage checked. \n\t" + combinations.ToString() + " combinations actually attempted.";
        }
    }
}
