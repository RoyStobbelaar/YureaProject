using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.EffectClasses
{
    public class BaseEffectDataManager
    {
        #region Fields & Properties Region

        readonly Dictionary<string, BaseEffectData> effectData;

        public Dictionary<string, BaseEffectData> EffectData
        {
            get { return effectData; }
        }

        #endregion
        #region Constructor Region

        public BaseEffectDataManager()
        {
            effectData = new Dictionary<string, BaseEffectData>();
        }

        #endregion
        #region Methods Region
        #endregion
        #region Virtual Methods region
        #endregion
    }
}
