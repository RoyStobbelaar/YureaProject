using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.TalentClasses
{
    public class TalentDataManager
    {

        #region Fields & Properties Region

        readonly Dictionary<string, TalentData> talentData;

        public Dictionary<string, TalentData> TalentData
        {
            get { return talentData;}
        }

        #endregion



        #region Constructor Region

        public TalentDataManager()
        {
            talentData = new Dictionary<string, TalentData>();
        }

        #endregion




        #region Methods Region
        #endregion




        #region Virtual Methods region
        #endregion
    }
}
