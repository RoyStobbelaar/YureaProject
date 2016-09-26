using RpgLibrary.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.CharacterClasses;

namespace XRpgLibrary.EffectClasses
{
    public enum EffectType { Damage,Heal }

    public abstract class BaseEffect
    {
        #region Fields & Properties Region

        protected string name;

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        #endregion
        #region Constructor Region

        protected BaseEffect()
        {

        }

        #endregion
        #region Methods Region
        #endregion
        #region Virtual Methods region

        public abstract void Apply(Entity entity);

        #endregion
    }
}
