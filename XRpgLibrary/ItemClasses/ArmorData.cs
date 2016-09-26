using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.ItemClasses;

namespace RpgLibrary.ItemClasses
{
    public class ArmorData
    {
        #region Fields & Properties

        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public ArmorLocation ArmorLocation;
        public int DefenseValue;
        public int DefenseModifier;
        public string[] AllowableClasses;

        #endregion

        #region Constructor Region

        public ArmorData()
        {

        }

        #endregion

        #region Methods Region

        public override string ToString()
        {
            string toString = Name += ", ";
            toString += Type + ", ";
            toString += Price.ToString() + ", ";
            toString += Weight.ToString() + ", ";
            toString += ArmorLocation.ToString() + ", ";
            toString += DefenseValue.ToString() + ", ";
            toString += DefenseModifier.ToString();

            foreach (string s in AllowableClasses)
                toString += ", " + s;

            return toString;
        }
        #endregion
    }
}
