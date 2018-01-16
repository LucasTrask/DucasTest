using System;
using System.Collections.Generic;
using System.Text;
using Decal.Adapter.Wrappers;

namespace DucasTest.Vendors
{
    class BuyingUtils
    {

        public static void AddKitsAndNotesToBuyTab()
        {
            WorldObjectCollection items = Globals.Core.WorldFilter.GetByContainer(Globals.Core.CharacterFilter.Id);
            int total = 0;
            int used = 0;
            foreach (WorldObject item in items)
            {
                total++;
                switch (item.Name)
                {
                    case "Treated Healing Kit":
                    case "Trade Note (5,000)":
                    case "Trade Note (10,000)":
                    case "Trade Note (50,000)":
                        used++;
                        AddItemToBuyTab(item.Id);
                        break;
                    case "Pack":
                    case "Sack":
                        total--;
                        break;
                    default:
                        break;
                }
            }
            Util.WriteToChat("Added " + used.ToString() + " items out of " + total.ToString() + ".", ChatUtil.Color.orange);

        }

        public static void AddItemToBuyTab(int itemId)
        {
            Globals.Core.Actions.VendorAddSellList(itemId);
        }

        public static void SellAllBuyTab()
        {
            Globals.Core.Actions.VendorSellAll();
        }

    }
}
