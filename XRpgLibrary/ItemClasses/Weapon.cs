using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.EffectClasses;

namespace RpgLibrary.ItemClasses
{
    public class Weapon : BaseItem
    {

        #region Fields & Properties

        Hands hands;
        int attackValue;
        int attackModifier;
        DamageEffectData damageEffectData;
        //int damageValue;
        //int damageModifier;

        public Hands NumberHands
        {
            get { return hands; }
            protected set { hands = value; }
        }

        public int AttackValue
        {
            get { return attackValue; }
            protected set { attackValue = value; }
        }

        public int AttackModifier
        {
            get { return attackModifier; }
            protected set { attackModifier = value; }
        }

        public DamageEffectData DamageEffectData
        {
            get { return damageEffectData; }
            protected set { damageEffectData = value; }
        }

        //public int DamageValue
        //{
        //    get { return damageValue; }
        //    protected set { damageValue = value; }
        //}

        //public int DamageModifier
        //{
        //    get { return damageModifier; }
        //    protected set { damageModifier = value; }
        //}

        #endregion

        #region Constructor Region

        public Weapon(string weaponName, string weaponType, int price, float weight, Hands hands, 
            int attackValue, int attackModifier, DamageEffectData damageEffectData, params string[] allowableClasses)
            : base(weaponName,weaponType,price,weight,allowableClasses)
        {
            NumberHands = hands;
            AttackValue = attackValue;
            AttackModifier = attackModifier;
            DamageEffectData = damageEffectData;
            //DamageValue = damageValue;
            //DamageModifier = damageModifier;
        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {
            string[] allowedClasses = new string[allowableClasses.Count];

            for (int i = 0; i < allowableClasses.Count; i++)
                allowedClasses[i] = allowableClasses[i];

            Weapon weapon = new Weapon(
                Name, Type, Price, Weight, NumberHands, AttackValue, AttackModifier, DamageEffectData, allowedClasses);

            return weapon;
        }

        public override string ToString()
        {
            string weaponString = base.ToString() + ", ";
            weaponString += NumberHands.ToString() + ", ";
            weaponString += attackValue.ToString() + ", ";
            weaponString += attackModifier.ToString() + ", ";
            weaponString += damageEffectData.ToString();
            //weaponString += damageValue.ToString() + ", ";
            //weaponString += damageModifier.ToString();

            foreach (string t in allowableClasses)
                weaponString += ", " + t;

            return weaponString;
        }

        #endregion
    }
}