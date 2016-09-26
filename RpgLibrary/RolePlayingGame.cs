using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary
{
    public class RolePlayingGame
    {
        #region Fields & Properties

        string name;
        string description;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        #endregion

        #region Constructor Method

        public RolePlayingGame()
        {

        }

        public RolePlayingGame(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        #endregion

    }
}
