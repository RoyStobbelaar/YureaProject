using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public class SkillData
    {
        #region Fields & Properties Region

        public string Name;
        public string PrimaryAttribute;
        public Dictionary<string, int> ClassModifiers;

        #endregion

        #region Constructor Region

        public SkillData()
        {
            ClassModifiers = new Dictionary<string, int>();
        }

        #endregion

        #region Methods Region
        #endregion

        #region Virtual Methods region

        public override string ToString()
        {
            string toString = Name + ", ";
            toString += PrimaryAttribute;

            foreach (string s in ClassModifiers.Keys)
                toString += ", " + s + "+" + ClassModifiers[s].ToString();

            return toString;

        }

        #endregion
    }
}
