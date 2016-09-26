using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class EntityDataManager
    {
        #region Fields & Properties

        readonly Dictionary<string, EntityData> entityData = new Dictionary<string, EntityData>();

        public Dictionary<string, EntityData> EntityData
        {
            get { return entityData; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Methods Region
        #endregion
    }
}
