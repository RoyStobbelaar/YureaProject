using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public enum DifficultyLevel
    {
        Master = -25,
        Expert = -10,
        Improved = -5,
        Normal = 0,
        Easy=10,
    }

    public class Skill
    {

        #region Fields & Properties Region

        string skillName;
        string primaryAttribute;
        readonly Dictionary<string, int> classModifiers;
        int skillValue;

        public string SkillName
        {
            get { return skillName; }
        }

        public string PrimaryAttribute
        {
            get { return primaryAttribute; }
        }

        public int SkillValue
        {
            get { return skillValue; }
        }

        public Dictionary<string, int> ClassModifiers
        {
            get { return classModifiers; }
        }

        #endregion


        #region Constructor Region

        private Skill()
        {
            skillName = "";
            primaryAttribute = "";
            classModifiers = new Dictionary<string, int>();
            skillValue = 0;
        }

        #endregion


        #region Methods Region

        public void IncreaseSkill(int value)
        {
            skillValue += value;

            if (skillValue > 100)
                skillValue = 100;
        }

        public void DecreaseSkill(int value)
        {
            skillValue -= value;

            if (skillValue < 0)
                skillValue = 0;
        }

        public static Skill FromSkillData(SkillData data)
        {
            Skill skill = new Skill();
            skill.skillName = data.Name;
            skill.skillValue = 0;

            foreach(string s in data.ClassModifiers.Keys)
            {
                skill.classModifiers.Add(s, data.ClassModifiers[s]);
            }

            return skill;
        }

        public static int AttributeModifier(int attribute)
        {
            int result = 0;

            if (attribute < 25)
                result = 1;
            else if (attribute < 50)
                result = 2;
            else if (attribute < 75)
                result = 3;
            else if (attribute < 90)
                result = 4;
            else if (attribute < 95)
                result = 5;
            else
                result = 10;

            return result;
        }

        #endregion


        #region Virtual Methods region
        #endregion
    }
}
