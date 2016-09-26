using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.EffectClasses
{
    public class Weakness
    {
        #region Fields & Properties Region

        DamageType weakness;
        int amount;

        public DamageType WeaknessType
        {
            get { return weakness; }
            private set { weakness = value; }
        }

        public int Amount
        {
            get { return amount; }
            private set
            {
                if (value < 0)
                    amount = 0;
                else if (value > 100)
                    value = 100;
                else
                    amount = value;
            }
        }

        #endregion
        #region Constructor Region

        public Weakness(WeaknessData data)
        {
            WeaknessType = data.WeaknessType;
            Amount = data.Amount;
        }

        #endregion
        #region Methods Region

        public int Apply(int damage)
        {
            return (damage + damage * amount / 100);
        }

        #endregion
        #region Virtual Methods region
        #endregion
    }
}
