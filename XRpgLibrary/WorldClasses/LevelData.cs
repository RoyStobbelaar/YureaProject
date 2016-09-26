using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{
    public class LevelData
    {
        public string LevelName;
        public string MapName;
        public int MapWidth;
        public int MapHeight;
        public string[] CharacterNames;
        public string[] ChestNames;
        public string[] TrapNames;

        private LevelData()
        {

        }

        public LevelData(string ln, string mp, int mw, int mh, List<string>chars, List<string>chests, List<string> traps)
        {
            LevelName = ln;
            MapName = mp;
            MapWidth = mw;
            MapHeight = mh;
            CharacterNames = chars.ToArray();
            ChestNames = chests.ToArray();
            TrapNames = traps.ToArray();
        }
    }
}
