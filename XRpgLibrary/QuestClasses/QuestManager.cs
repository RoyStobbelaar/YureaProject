using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.QuestClasses
{
    public class QuestManager
    {

        #region Fields & Properties Region

        readonly Dictionary<string, Quest> quests;

        public Dictionary<string, Quest> Quests
        {
            get { return quests; }
        }

        #endregion




        #region Constructor Region

        public QuestManager()
        {
            quests = new Dictionary<string, Quest>();
        }

        #endregion




        #region Methods Region
        #endregion




        #region Virtual Methods region
        #endregion

    }
}
