using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DucasTest.Character
{
    class ExperienceCalculator
    {
        public static String GetCurrentLevel()
        {           
            return Globals.Core.CharacterFilter.Level.ToString();
        }
    }
}
