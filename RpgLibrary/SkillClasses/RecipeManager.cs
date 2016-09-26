using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.SkillClasses
{
    public class RecipeManager
    {

        #region Fields & Properties Region

        readonly Dictionary<string, Recipe> recipies;

        public Dictionary<string, Recipe> Recipies
        {
            get { return recipies; }
        }

        #endregion


        #region Constructor Region

        public RecipeManager()
        {
            recipies = new Dictionary<string, Recipe>();
        }

        #endregion


        #region Methods Region
        #endregion


        #region Virtual Methods region
        #endregion
    }
}
