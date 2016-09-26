using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public class Backpack
    {
        #region Fields & Properties Region

        readonly List<GameItem> items;

        public List<GameItem> Items
        {
            get { return items; }
        }

        public int Capacity
        {
            get { return items.Count; }
        }

        #endregion

        #region Constructor Region

        public Backpack()
        {
            items = new List<GameItem>();
        }

        #endregion

        #region Methods Region

        public void AddItem(GameItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(GameItem item)
        {
            items.Remove(item);
        }

        #endregion

        #region Virtual Methods region
        #endregion
    }
}
