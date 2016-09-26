using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.ItemClasses
{
    public class GameItem
    {
        #region Fields & Properties Region

        public Vector2 Position;

        private Texture2D image;
        private Rectangle? sourceRectangle;
        private readonly BaseItem baseItem;
        private Type type;

        public Texture2D Image
        {
            get { return image; }
        }

        public Rectangle? SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }

        public BaseItem Item
        {
            get { return baseItem; }
        }

        public Type Type
        {
            get { return type; }
        }

        #endregion

        #region Constructor Region

        public GameItem(BaseItem item, Texture2D texture, Rectangle? source)
        {
            baseItem = item;
            image = texture;
            sourceRectangle = source;

            type = item.GetType();
        }

        #endregion

        #region Methods Region

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, sourceRectangle, Color.White);
        }

        #endregion

        #region Virtual Methods region
        #endregion
    }
}
