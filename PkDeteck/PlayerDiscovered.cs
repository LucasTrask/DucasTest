using System;
using System.Collections.Generic;
using System.Text;
using Decal.Adapter.Wrappers;
using DucasTest;

namespace DucasTest.PkDeteck
{
    class PlayerDiscovered
    {
        public static void ProcessPlayer(WorldObject worldObject, int myMonarchId, bool LogOnUnknown, bool LogOnFriendly, bool LogOnEnemy)
        {
            CoordsObject theirCoords = worldObject.Coordinates();
            CoordsObject myCoords = new CoordsObject(Globals.Core.Actions.LocationY, Globals.Core.Actions.LocationX);

            int theirId = worldObject.Id;
            int myId = Globals.Core.CharacterFilter.Id;            
            double distance = Globals.Core.WorldFilter.Distance(myId, theirId);

            //Globals.Host.Decal.

            if (worldObject.Values(LongValueKey.Monarch) == 0)
            {
                Util.WriteToChat("Unaligned Player Detected: " + worldObject.Name + " at " + worldObject, ChatUtil.Color.orange);
                if (LogOnUnknown)
                {
                    Logout();
                    Util.WriteToChat("LOGGING OUT!!!", ChatUtil.Color.white);
                }

            }
            else if ((Globals.Core.CharacterFilter.Monarch != null) && (myMonarchId == worldObject.Values(LongValueKey.Monarch)))
            {
                Util.WriteToChat("Ally Detected: " + worldObject.Name + " :: " + worldObject.Values(StringValueKey.MonarchName), ChatUtil.Color.orange);
                if (LogOnFriendly)
                {
                    Logout();
                    Util.WriteToChat("LOGGING OUT!!!", ChatUtil.Color.white);
                }
            }
            else
            {
                Util.WriteToChat("Enemy Detected: " + worldObject.Name + " :: " + worldObject.Values(StringValueKey.MonarchName), ChatUtil.Color.orange);
                if (LogOnEnemy)
                {
                    Logout();
                    Util.WriteToChat("LOGGING OUT!!!", ChatUtil.Color.white);
                }
            }

        }

        private static void Logout()
        {
            for (int i = 0; i < 100; i++)
            {
                Globals.Host.Actions.Logout();
            }
        }

    }
}
