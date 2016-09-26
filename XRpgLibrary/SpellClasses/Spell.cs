using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.CharacterClasses;

namespace RpgLibrary.SpellClasses
{
    public class Spell
    {
        #region Fields & Properties Region

        string name;
        List<string> allowedClasses;
        Dictionary<string, int> attributeRequirements;
        List<string> spellPrerequisites;
        int levelRequirement;
        SpellType spellType;
        int activationCost;
        List<string> effects;

        public string Name
        {
            get { return name; }
        }

        public List<string> AllowedClasses
        {
            get { return allowedClasses; }
        }

        public Dictionary<string, int> AttributeRequirements
        {
            get { return attributeRequirements; }
        }

        public List<string> SpellPrerequisites
        {
            get { return spellPrerequisites; }
        }

        public int LevelRequirement
        {
            get { return levelRequirement; }
        }

        public SpellType SpellType
        {
            get { return spellType; }
        }

        public int ActivationCost
        {
            get { return activationCost; }
        }

        public List<string> Effects
        {
            get { return effects; }
        }

        #endregion
        #region Constructor Region

        private Spell()
        {
            allowedClasses = new List<string>();
            attributeRequirements = new Dictionary<string, int>();
            spellPrerequisites = new List<string>();
            effects = new List<string>();
        }

        public static Spell FromSpellData(SpellData data)
        {
            Spell spell = new Spell();

            spell.name = data.Name;

            foreach (string s in data.AllowedClasses)
                spell.allowedClasses.Add(s.ToLower());

            foreach (string s in data.AttributeRequirements.Keys)
                spell.attributeRequirements.Add(s.ToLower(), data.AttributeRequirements[s]);

            foreach (string s in data.SpellPrerequisites)
                spell.spellPrerequisites.Add(s);

            spell.levelRequirement = data.LevelRequirement;
            spell.spellType = data.SpellType;
            spell.activationCost = data.ActivationCost;

            foreach (string s in data.Effects)
                spell.effects.Add(s);

            return spell;
        }

        public static bool CanLearn(Entity entity, Spell spell)
        {
            bool canLearn = true;

            if (entity.Level < spell.levelRequirement)
                canLearn = false;

            string entityClass = entity.EntityClass.ToLower();

            if (!spell.AllowedClasses.Contains(entityClass))
                canLearn = false;

            foreach(string s in spell.AttributeRequirements.Keys)
            {
                if(Mechanics.GetAttributeByString(entity,s) < spell.AttributeRequirements[s])
                {
                    canLearn = false;
                    break;
                }
            }

            foreach(string s in spell.spellPrerequisites)
            {
                if (!entity.Spells.ContainsKey(s))
                {
                    canLearn = false;
                    break;
                }
            }

            return canLearn;
        }

        #endregion
        #region Methods Region
        #endregion
        #region Virtual Methods region
        #endregion
    }
}
