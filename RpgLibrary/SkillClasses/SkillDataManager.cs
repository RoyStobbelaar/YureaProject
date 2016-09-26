using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public class SkillDataManager
    {

        #region Fields & Properties Region

        readonly Dictionary<string, SkillData> skillData;

        public Dictionary<string, SkillData> SkillData
        {
            get { return skillData; }
        }

        #endregion


        #region Constructor Region

        public SkillDataManager()
        {
            skillData = new Dictionary<string, SkillData>();
        }

        #endregion


        #region Methods Region
        #endregion


        #region Virtual Methods region
        #endregion
    }
}
