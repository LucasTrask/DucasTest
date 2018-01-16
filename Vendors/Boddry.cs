using System;
using System.Collections.Generic;
using System.Text;

namespace DucasTest.Vendors
{
    class Boddry
    {
        /*
        public static void TestBuyTokens()
        {
            boddry_id = 1;
            WorldObjectCollection nearby_vendors = Globals.Core.WorldFilter.GetByObjectClass(ObjectClass.Vendor);
            foreach (WorldObject vendor in nearby_vendors)
            {
                Util.WriteToChat(vendor.Name + "  " + vendor.Id.ToString());
                if (vendor.Name.Equals("Boddry the Chancy"))
                {
                    boddry_id = vendor.Id;
                }
            }

            if (boddry_id == 1)
            {
                return;
            }

            aTimer.Elapsed += new ElapsedEventHandler(UseBoddry);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;

            Util.WriteToChat(Globals.Core.Actions.VendorId.ToString());
        }*/
        /*
        private static void UseBoddry(object source, ElapsedEventArgs e)
        {
            if (Globals.Core.Actions.VendorId == boddry_id)
            {
                aTimer.Enabled = false;
            }
            else
            {
                Globals.Core.Actions.Heading = 5.0;
                Globals.Core.Actions.UseItem(boddry_id, 1);
            }

        }*/

    }
}
