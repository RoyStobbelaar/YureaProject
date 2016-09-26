using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public class GameItemManager
    {
        #region Fields & Properties Region

        readonly Dictionary<string, GameItem> gameItems = new Dictionary<string, GameItem>();
        static SpriteFont spriteFont;

        public Dictionary<string, GameItem> GameItems
        {
            get { return gameItems; }
        }

        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
            private set { spriteFont = value; }
        }

        #endregion


        #region Constructor Region

        public GameItemManager(SpriteFont spriteFont)
        {
            SpriteFont = spriteFont;
        }

        #endregion


        #region Methods Region
        #endregion


        #region Virtual Methods region
        #endregion
    }
}
