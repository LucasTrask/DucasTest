using System.Collections.Generic;
using System.Threading;

namespace DucasTest.Spellbars
{
    class MageSpells
    {
        private static List<List<int>> allTabs;
        private static List<int> slash;
        private static List<int> pierce;
        private static List<int> bludge;
        private static List<int> acid;
        private static List<int> fire;
        private static List<int> frost;
        private static List<int> light;

        private static void SetAllTabs()
        {
            allTabs = new List<List<int>>();
            SetSlashOne();
            SetPierceOne();
            SetBludgeOne();
            SetAcidOne();
            SetFireOne();
            SetFrostOne();
            SetLightOne();
            
        }

        private static void SetSlashOne()
        {
            slash = new List<int>();
            slash.Add(1665); //s2h 2
            slash.Add(2759); // sa7
            slash.Add(2146);
            slash.Add(2147);
            slash.Add(2164);
            slash.Add(2073);
            slash.Add(2345);
            slash.Add(2083);
            slash.Add(2343);

            if (HasSpell(2074)) { slash.Add(2074); }
            else if (HasSpell(1327)) { slash.Add(1327); }
            else { Util.WriteToChat("Missing Imperil 6 or 7!"); }

            if (HasSpell(2100)) { slash.Add(2100); }
            else if (HasSpell(1492)) { slash.Add(1492); }
            else { Util.WriteToChat("Missing Brittlemail 6 or 7!"); }

            if (HasSpell(2095)) { slash.Add(2095); }
            else if (HasSpell(1557)) { slash.Add(1557); }
            else { Util.WriteToChat("Missing Slash Bait 6 or 7!");}

            if (HasSpell(1237)) { slash.Add(1237); }
            else { Util.WriteToChat("Missing Drain Health 1!"); }

            allTabs.Add(slash);
        }

        private static void SetPierceOne()
        {
            pierce = new List<int>();
            pierce.Add(1665);
            pierce.Add(2724);
            pierce.Add(2132);
            pierce.Add(2133);
            pierce.Add(2174);
            pierce.Add(2073);
            pierce.Add(2345);
            pierce.Add(2083);
            pierce.Add(2343);

            if (HasSpell(2074)) { pierce.Add(2074); }
            else if (HasSpell(1327)) { pierce.Add(1327); }

            if (HasSpell(2100)) { pierce.Add(2100); }
            else if (HasSpell(1492)) { pierce.Add(1492); }

            if (HasSpell(2114)) { pierce.Add(2114); }
            else if (HasSpell(1568)) { pierce.Add(1568); }
            else {Util.WriteToChat("Missing Pierce Bait 6 or 7!");}

            if (HasSpell(1237)) { pierce.Add(1237); } // drain health

            allTabs.Add(pierce);
        }


        private static void SetBludgeOne()
        {
            bludge = new List<int>();
            bludge.Add(1665);
            bludge.Add(2752);
            bludge.Add(2144);
            bludge.Add(2145);
            bludge.Add(2166);
            bludge.Add(2073);
            bludge.Add(2345);
            bludge.Add(2083);
            bludge.Add(2343);

            if (HasSpell(2074)) { bludge.Add(2074); }
            else if (HasSpell(1327)) { bludge.Add(1327); }

            if (HasSpell(2100)) { bludge.Add(2100); }
            else if (HasSpell(1492)) { bludge.Add(1492); }

            if (HasSpell(2099)) { bludge.Add(2099); }
            else if (HasSpell(1510)) { bludge.Add(1510); }
            else {Util.WriteToChat("Missing Bludge Bait 6 or 7!");}

            if (HasSpell(1237)) { bludge.Add(1237); }
            allTabs.Add(bludge);
        }

        private static void SetAcidOne()
        {
            acid = new List<int>();
            acid.Add(1665); // s2h2
            acid.Add(2717); // aa7
            acid.Add(2122); // ab7
            acid.Add(2121); // as7
            acid.Add(2162); //av7
            acid.Add(2073);
            acid.Add(2345);
            acid.Add(2083);
            acid.Add(2343);

            if (HasSpell(2074)) { acid.Add(2074); }
            else if (HasSpell(1327)) { acid.Add(1327); }

            if (HasSpell(2100)) { acid.Add(2100); }
            else if (HasSpell(1492)) { acid.Add(1492); }

            if (HasSpell(2093)) { acid.Add(2093); }
            else if (HasSpell(1504)) { acid.Add(1504); }
            else {Util.WriteToChat("Missing Acid Bait 6 or 7!");}

            if (HasSpell(1237)) { acid.Add(1237); }

            acid.Add(1635); // lifestone recall
            acid.Add(48); // i think primary portal recall
            acid.Add(2647); // secondary portal recall

            if (HasSpell(2645)) { acid.Add(2645); }
            else { Util.WriteToChat("Missing Portal Recall!"); }

            acid.Add(2644); // lifestone tie
            acid.Add(47); // i think primary portal tie
            acid.Add(2646); // secondary portal tie

            acid.Add(2709); // summon primary portal
            acid.Add(2648); // summon secondary portal

            allTabs.Add(acid);

        }

        private static void SetFireOne()
        {
            fire = new List<int>();
            fire.Add(1665);
            fire.Add(2745);
            fire.Add(2128);
            fire.Add(2129);
            fire.Add(2170);
            fire.Add(2073);
            fire.Add(2345);
            fire.Add(2083);
            fire.Add(2343);

            if (HasSpell(2074)) { fire.Add(2074); }
            else if (HasSpell(1327)) { fire.Add(1327); }

            if (HasSpell(2100)) { fire.Add(2100); }
            else if (HasSpell(1492)) { fire.Add(1492); }

            if (HasSpell(2103)) { fire.Add(2103); }
            else if (HasSpell(1546)) { fire.Add(1546); }
            else {Util.WriteToChat("Missing Fire Bait 6 or 7!"); }

            if (HasSpell(1237)) { fire.Add(1237); }

            if (HasSpell(2108)) { fire.Add(2108); }
            else if (HasSpell(1486)) { fire.Add(1486); }
            else { Util.WriteToChat("Missing Impenetrability 6 or 7!"); }

            if (HasSpell(2094)) { fire.Add(2094); }
            else if (HasSpell(1562)) { fire.Add(1562); }
            else { Util.WriteToChat("Missing Blade Bane 6 or 7!"); }

            if (HasSpell(2113)) { fire.Add(2113); }
            else if (HasSpell(1574)) { fire.Add(1574); }
            else { Util.WriteToChat("Missing Pierce Bane 6 or 7!"); }

            if (HasSpell(2098)) { fire.Add(2098); }
            else if (HasSpell(1516)) { fire.Add(1516); }
            else { Util.WriteToChat("Missing Bludge Bane 6 or 7!"); }

            if (HasSpell(2092)) { fire.Add(2092); }
            else if (HasSpell(1498)) { fire.Add(1498); }
            else { Util.WriteToChat("Missing Acid Bane 6 or 7!"); }

            if (HasSpell(2102)) { fire.Add(2102); }
            else if (HasSpell(1552)) { fire.Add(1552); }
            else { Util.WriteToChat("Missing Fire Bane 6 or 7!"); }

            if (HasSpell(2104)) { fire.Add(2104); }
            else if (HasSpell(1528)) { fire.Add(1528); }
            else { Util.WriteToChat("Missing Frost Bane 6 or 7!"); }

            if (HasSpell(2110)) { fire.Add(2110); }
            else if (HasSpell(1540)) { fire.Add(1540); }
            else { Util.WriteToChat("Missing Light Bane 6 or 7!"); }

            allTabs.Add(fire);


        }

        private static void SetFrostOne()
        {
            frost = new List<int>();
            frost.Add(1665);
            frost.Add(2731);
            frost.Add(2136);
            frost.Add(2137);
            frost.Add(2168);
            frost.Add(2073);
            frost.Add(2345);
            frost.Add(2083);
            frost.Add(2343);

            if (HasSpell(2074)) { frost.Add(2074); }
            else if (HasSpell(1327)) { frost.Add(1327); }

            if (HasSpell(2100)) { frost.Add(2100); }
            else if (HasSpell(1492)) { frost.Add(1492); }

            if (HasSpell(2105)) { frost.Add(2105); }
            else if (HasSpell(1522)) { frost.Add(1522); }
            else { Util.WriteToChat("Missing Frost Bait 6 or 7!");}

            if (HasSpell(1237)) { frost.Add(1237); }

            allTabs.Add(frost);

        }

        private static void SetLightOne()
        {
            light = new List<int>();
            light.Add(1665);
            light.Add(2738);
            light.Add(2140);
            light.Add(2141);
            light.Add(2172);
            light.Add(2073);
            light.Add(2345);
            light.Add(2083);
            light.Add(2343);

            if (HasSpell(2074)) { light.Add(2074); }
            else if (HasSpell(1327)) { light.Add(1327); }

            if (HasSpell(2100)) { light.Add(2100); }
            else if (HasSpell(1492)) { light.Add(1492); }

            if (HasSpell(2111)) { light.Add(2111); }
            else if (HasSpell(1534)) { light.Add(1534); }
            else {Util.WriteToChat("Missing Light Bait 6 or 7!");}

            if (HasSpell(1237)) { light.Add(1237); }

            allTabs.Add(light);
        }

        public static void SetMageBars()
        {
            SetAllTabs();

            for (int i = 0; i < allTabs.Count; i++)
            {
                LoopTabs(allTabs[i], i);
            }

        }

        private static void LoopTabs(List<int> spells, int tab)
        {

            for (int i = 0; i < spells.Count; i++)
            {
                Globals.Host.Actions.SpellTabAdd(tab, i, spells[i]);
                //Thread.Sleep(50);
            }

        }

        private static bool HasSpell(int spell)
        {
            return Globals.Core.CharacterFilter.SpellBook.Contains(spell);
        }

























    }
}
