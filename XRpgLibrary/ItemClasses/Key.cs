using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.ItemClasses;

namespace RpgLibrary.ItemClasses
{
    public class Key : BaseItem
    {
        #region Fields & Properties Region
        #endregion


        #region Constructor Region

        public Key(string name, string type) : base(name, type, 0, 0, null)
        {

        }

        #endregion


        #region Methods Region
        #endregion


        #region Virtual Methods region

        public override object Clone()
        {
            Key key = new Key(this.Name, this.Type);

            return key;
        }

        #endregion
    }
}
