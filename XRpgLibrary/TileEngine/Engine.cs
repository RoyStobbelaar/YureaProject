﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.TileEngine
{
    public class Engine
    {
        #region Fields & Properies

        static int tileWidth;
        static int tileHeight;

        public static int TileWidth
        {
            get { return tileWidth; }
        }

        public static int TileHeight
        { 
             get{ return tileHeight; } 
        }

        #endregion

        #region Constructor

        public Engine(int tileWidth, int tileHeight)
        {
            Engine.tileWidth = tileWidth;
            Engine.tileHeight = tileHeight;
        }

        #endregion

        #region Methods

        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / tileWidth, (int)position.Y / tileHeight);
        }

        #endregion
    }
}
