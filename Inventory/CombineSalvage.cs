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

        /*
        private static void addTypes()
        {
            salvageTypesToCombine.Clear();

            // weapon types
            salvageTypesToCombine.Add(Salvage.Brass.ToString()); // weapon melee d modifier
            salvageTypesToCombine.Add(Salvage.Iron.ToString()); // weapon damage
            salvageTypesToCombine.Add(Salvage.Granite.ToString()); // 20% weapon variance 
            salvageTypesToCombine.Add(Salvage.Oak.ToString()); // weapon speed
            salvageTypesToCombine.Add(Salvage.Mahogany.ToString()); // missile % damage mod

            // armor types
            salvageTypesToCombine.Add(Salvage.Steel.ToString()); // armor level
            salvageTypesToCombine.Add(Salvage.Peridot.ToString()); // melee d +1 modifier

            // imbue types
            salvageTypesToCombine.Add(Salvage.BlackGarnet.ToString()); // pierce
            salvageTypesToCombine.Add(Salvage.WhiteSaphire.ToString()); // bludge
            salvageTypesToCombine.Add(Salvage.ImperialTopaz.ToString()); // slash
            salvageTypesToCombine.Add(Salvage.RedGarnet.ToString()); // fire
            salvageTypesToCombine.Add(Salvage.Jet.ToString()); // lightning
            salvageTypesToCombine.Add(Salvage.Emerald.ToString()); // acid
            salvageTypesToCombine.Add(Salvage.Aquamarine.ToString()); // cold
            salvageTypesToCombine.Add(Salvage.Sunstone.ToString()); // armor rending
            salvageTypesToCombine.Add(Salvage.BlackOpal.ToString()); // critcal strike

            // item types
            salvageTypesToCombine.Add(Salvage.Pine.ToString()); // reduce cost
            salvageTypesToCombine.Add(Salvage.Leather.ToString()); // retain
            salvageTypesToCombine.Add(Salvage.Ivory.ToString()); // remove stuck on char
        } */


    }
}
