using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ConversationClasses
{
    public class ConversationManager
    {

        #region Fields & Properties Region

        readonly Dictionary<string, Conversation> conversations;

        public Dictionary<string, Conversation> Conversation
        {
            get { return conversations; }
        }

        #endregion



        #region Constructor Region

        public ConversationManager()
        {
            conversations = new Dictionary<string, Conversation>();
        }

        #endregion



        #region Methods Region
        #endregion



        #region Virtual Methods region
        #endregion
    }
}
