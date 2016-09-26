using RpgLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.EffectClasses
{
    public enum HealType { Health, Mana, Stamina }

    public class HealEffectData : BaseEffectData
    {
        #region Fields & Properties Region

        public HealType HealType;
        public DieType DieType;
        public int NumberOfDice;
        public int Modifier;

        #endregion

        #region Constructor Region
        #endregion

        #region Methods Region
        #endregion

        #region Virtual Methods region
        #endregion
    }
}
