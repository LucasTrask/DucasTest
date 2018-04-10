using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DucasTest.Inventory
{
    class BuildInventoryMap
    {

        /**
         * Takes a list of Items names, if it finds any of them, it'll build a list for each to do whatever you want to do with it. 
         */
        public static MultiMap<int> FromInventory(List<String> itemTypesToLookFor)
        {
            WorldObjectCollection items = Globals.Core.WorldFilter.GetByContainer(Globals.Core.CharacterFilter.Id);

            MultiMap<int> mVD = new MultiMap<int>();

            foreach (WorldObject item in items)
            {
                if (!item.ObjectClass.ToString().Equals("Salvage"))
                {
                    //Util.WriteToChat(item.ObjectClass.ToString() + " item found. This is not salvage! ");
                } else
                {
                    mVD.Add(item.Type.ToString(), item.Id);
                }
            }

            return mVD;
        }


    }
}
