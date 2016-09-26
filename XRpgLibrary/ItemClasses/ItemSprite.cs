using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.SpriteClasses;

namespace XRpgLibrary.ItemClasses
{
    public class ItemSprite
    {
        #region Fields & Properties Region

        BaseSprite sprite;
        BaseItem item;

        public BaseSprite Sprite
        {
            get { return sprite; }
        }

        public BaseItem Item
        {
            get { return item; }
        }

        #endregion


        #region Constructor Region

        public ItemSprite(BaseItem item, BaseSprite sprite)
        {
            this.item = item;
            this.sprite = sprite;
        }

        #endregion

        #region Methods Region
        #endregion

        #region Virtual Methods region

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Draw(gameTime, spriteBatch);
        }

        #endregion
    }
}
