using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.CharacterClasses
{
    public class EntityData
    {
        #region Fields & Properties

        public string EntityName;
        public int Strength;
        public int Dexterity;
        public int Cunning;
        public int Willpower;
        public int Magic;
        public int Constitution;

        public string HealthFormula;
        public string StaminaFormula;
        public string MagicFormula;

        #endregion

        #region Constructor Region

        private EntityData()
        {

        }

        public EntityData(string entityName, int str, int dex, int cun, int will, int magic, int con, string health, string stam, string mana)
        {
            EntityName = entityName;
            Strength = str;
            Dexterity = dex;
            Cunning = cun;
            Willpower = will;
            Magic = magic;
            Constitution = con;
            HealthFormula = health;
            StaminaFormula = stam;
            MagicFormula = mana;
        }

        #endregion

        #region Methods Region

        public override string ToString()
        {
            string toString = EntityName + ", ";
            toString += Strength.ToString() + ", ";
            toString += Dexterity.ToString() + ", ";
            toString += Cunning.ToString() + ", ";
            toString += Willpower.ToString() + ", ";
            toString += Magic.ToString() + ", ";
            toString += Constitution.ToString() + ", ";
            toString += HealthFormula + ", ";
            toString += StaminaFormula + ", ";
            toString += MagicFormula;

            return toString;
        }

        public object Clone()
        {
            EntityData data = new EntityData();
            data.EntityName = this.EntityName;
            data.Strength = this.Strength;
            data.Dexterity = this.Dexterity;
            data.Cunning = this.Cunning;
            data.Willpower = this.Willpower;
            data.Magic = this.Magic;
            data.Constitution = this.Constitution;
            data.HealthFormula = this.HealthFormula;
            data.StaminaFormula = this.StaminaFormula;
            data.MagicFormula = this.MagicFormula;

            return data;
        }

        //public static void ToFile(string filename)
        //{

        //}

        //public static EntityData FromFile(string filename)
        //{
        //    EntityData entity = new EntityData();
        //    return entity;
        //}

        #endregion

    }
}
