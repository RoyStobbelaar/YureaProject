﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class LeftRightSelector : Control
    {
        #region Event region

        public event EventHandler SelectionChanged;

        #endregion;

        #region Fields & Properties

        List<string> items = new List<string>();

        Texture2D leftTexture;
        Texture2D rightTexture;
        Texture2D stopTexture;

        Color selectedColor = Color.Red;
        int maxItemWidth;
        int selectedItem;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        public int SelectedIndex
        {
            get { return selectedItem; }
            set { selectedItem = (int)MathHelper.Clamp(value, 0f, items.Count); }
        }

        public string Selecteditem
        {
            get { return Items[selectedItem]; }
        }

        public List<string> Items
        {
            get { return items; }
        }

        #endregion

        #region Constructor Region

        public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
        {
            leftTexture = leftArrow;
            rightTexture = rightArrow;
            stopTexture = stop;
            tapStop = true;
            Color = Color.White;
        }

        #endregion

        #region Method Region

        public void SetItems(string[] items, int maxWidth)
        {
            this.items.Clear();

            foreach (string s in items)
                this.items.Add(s);

            maxItemWidth = maxWidth;
        }

        protected void OnSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, null);
        }

        #endregion

        #region Abstract Class Methods

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawTo = position;

            if (selectedItem != 0)
                spriteBatch.Draw(leftTexture, drawTo, Color.White);
            else
                spriteBatch.Draw(stopTexture, drawTo, Color.White);

            drawTo.X += leftTexture.Width + 5f;

            float itemWidth = spriteFont.MeasureString(items[selectedItem]).X;
            float offset = (maxItemWidth - itemWidth) / 2;

            drawTo.X += offset;

            if (hasFocus)
                spriteBatch.DrawString(spriteFont, items[selectedItem], drawTo, selectedColor);
            else
                spriteBatch.DrawString(spriteFont, items[selectedItem], drawTo, Color);

            drawTo.X += -1 * offset + maxItemWidth + 5f;

            if (selectedItem != items.Count - 1)
                spriteBatch.Draw(rightTexture, drawTo, Color.White);
            else
                spriteBatch.Draw(stopTexture, drawTo, Color.White);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (items.Count == 0)
                return;

            if(InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft,playerIndex) ||
                InputHandler.ButtonReleased(Buttons.DPadLeft,playerIndex) ||
                InputHandler.KeyReleased(Keys.Left))
            {
                selectedItem--;
                if (selectedItem < 0)
                    selectedItem = 0;
                OnSelectionChanged();
            }

            if (InputHandler.ButtonReleased(Buttons.RightThumbstickRight, playerIndex) ||
                    InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
                    InputHandler.KeyReleased(Keys.Right))
            {
                selectedItem++;
                if (selectedItem >= items.Count)
                    selectedItem = items.Count-1;
                OnSelectionChanged();
            }
        }

        #endregion
    }
}