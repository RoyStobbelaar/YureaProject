using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.ItemClasses;

namespace RpgLibrary.ItemClasses
{
    public class WeaponData
    {
        #region Fields & Properties

        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public Hands NumberHands;
        public int AttackValue;
        public int AttackModifier;
        public int DamageValue;
        public int DamageModifier;
        public string[] AllowableClasses;

        #endregion

        #region Constructor Region

        public WeaponData()
        {

        }

        #endregion

        #region Methods Region

        public override string ToString()
        {
            string toString = Name + ", ";
            toString += Type + ", ";
            toString += Price.ToString() + ", ";
            toString += Weight.ToString() + ", ";
            toString += NumberHands.ToString() + ", ";
            toString += AttackValue.ToString() + ", ";
            toString += AttackModifier.ToString() + ", ";
            toString += DamageValue.ToString() + ", ";
            toString += DamageModifier.ToString();

            foreach (string s in AllowableClasses)
                toString += ", " + s;

            return toString;

        }

        #endregion
    }
}
