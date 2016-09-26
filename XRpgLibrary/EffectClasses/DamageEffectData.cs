using RpgLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.EffectClasses
{
    public enum DamageType { Weapon, Fire, Water, Earth, Air, Poison, Dark, Light}

    public enum AttackType { Health, Mana, Stamina}

    public class DamageEffectData : BaseEffectData
    {
        #region Fields & Properties Region

        public DamageType DamageType;
        public AttackType AttackType;
        public DieType DieType;
        public int NumberOfDice;
        public int Modifier;

        #endregion

        #region Constructor Region
        #endregion

        #region Methods Region
        #endregion

        #region Virtual Methods region

        public override string ToString()
        {
            string toString = Name + ", " + DamageType.ToString() + ", ";
            toString += AttackType.ToString() + ", ";
            toString += DieType.ToString() + ", ";
            toString += NumberOfDice.ToString() + ", ";
            toString += Modifier.ToString();

            return toString;
        }
        #endregion
    }
}
