using System;
using System.Collections.Generic;
using System.Text;
using Decal.Adapter;

namespace DucasTest.Spellbars
{
    class ClearSpells
    {

        public void ClearSpellTab (int TabNumber)
        {
            CoreManager.Current.CharacterFilter.SpellBar(1);

        }


    }
}
