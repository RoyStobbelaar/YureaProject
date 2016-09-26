using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.ItemClasses;

namespace RpgLibrary.ItemClasses
{
    public class Reagent : BaseItem
    {
        #region Fields & Properties Region
        #endregion


        #region Constructor Region

        public Reagent(string name, string type, int price, float weight, params string[] allowableClasses) : base(name, type, price, weight, allowableClasses)
        {
        }

        #endregion

        #region Methods Region
        #endregion

        #region Virtual Methods region

        public override object Clone()
        {
            Reagent reagent = new Reagent(Name, Type, Price, Weight);
            return reagent;
        }

        #endregion
    }
}
