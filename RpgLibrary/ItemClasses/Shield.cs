using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public class Shield : BaseItem
    {
        #region Fields & Properties

        int defenseValue;
        int defenseModifier;

        public int DefenseValue
        {
            get { return defenseValue; }
            protected set { defenseValue = value; }
        }

        public int DefenseModifier
        {
            get { return defenseModifier; }
            protected set { defenseModifier = value; }
        }

        #endregion

        #region Constructor Region

        public Shield(string name, string type, int price, float weight, int defenseValue, int defenseModifier, params string[] allowableClasses) : base(name, type, price, weight, allowableClasses)
        {
            DefenseValue = defenseValue;
            DefenseModifier = defenseModifier;
        }

        #endregion

        #region Abstract Methods

        public override object Clone()
        {
            string[] allowedClasses = new string[allowableClasses.Count];

            for (int i = 0; i < allowableClasses.Count; i++)
                allowedClasses[i] = allowableClasses[i];

            Shield shield = new Shield(Name, Type, Price, Weight, DefenseValue, DefenseModifier, allowedClasses);

            return shield;
        }

        public override string ToString()
        {
            string shieldString = base.ToString() + ", ";
            shieldString += defenseValue.ToString() + ", ";
            shieldString += defenseModifier.ToString();

            foreach (string t in allowableClasses)
                shieldString += ", " +t;

            return shieldString;
        }
        #endregion
    }
}