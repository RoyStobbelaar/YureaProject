using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.TileEngine
{
    public class Tile
    {

        #region Fields & Properties

        int tileIndex;
        int tileset;

        public int TileIndex
        {
            get { return tileIndex; }
            private set { tileIndex = value; }
        }

        public int Tileset
        {
            get { return tileset; }
            private set { tileset = value; }
        }

        #endregion

        #region Constructor Region

        public Tile(int tileIndex, int tileset)
        {
            TileIndex = tileIndex;
            Tileset = tileset;
        }

        #endregion
    }
}