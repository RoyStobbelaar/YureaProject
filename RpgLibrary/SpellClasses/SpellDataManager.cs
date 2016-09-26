using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SpellClasses
{
    public class SpellDataManager
    {
        #region Fields & Properties Region

        readonly Dictionary<string, SpellData> spellData;

        public Dictionary<string, SpellData> SpellData
        {
            get { return spellData; }
        }

        #endregion


        #region Constructor Region

        public SpellDataManager()
        {
            spellData = new Dictionary<string, SpellData>();
        }

        #endregion


        #region Methods Region

        #endregion


        #region Virtual Methods region

        #endregion

    }
}
