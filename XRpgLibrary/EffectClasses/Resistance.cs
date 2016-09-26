using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.EffectClasses
{
    public class Resistance
    {
        #region Fields & Properties Region

        DamageType resistance;
        int amount;

        public DamageType ResistanceType
        {
            get { return resistance; }
            private set { resistance = value; }
        }

        public int Amount
        {
            get { return amount; }
            private set
            {
                if (value < 0)
                    amount = 0;
                else if (value > 100)
                    amount = 100;
                else
                    amount = value;
            }
        }

        #endregion
        #region Constructor Region

        public Resistance(ResistanceData data)
        {
            ResistanceType = data.ResistanceType;
            Amount = data.Amount;
        }

        #endregion
        #region Methods Region

        public int Apply(int damage)
        {
            return (damage - damage * amount / 100);
        }

        #endregion
        #region Virtual Methods region
        #endregion
    }
}
