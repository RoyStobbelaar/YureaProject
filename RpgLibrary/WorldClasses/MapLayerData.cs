using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.WorldClasses
{
    public struct Tile
    {
        public int TileIndex;
        public int TileSetIndex;

        public Tile(int tileIndex, int tileSetIndex)
        {
            TileIndex = tileIndex;
            TileSetIndex = tileSetIndex;
        }
    }

    public class MapLayerData
    {
        public string MapLayerName;
        public int Width;
        public int Height;
        public Tile[] layer;

        private MapLayerData()
        {

        }

        public MapLayerData(string mapLayerName, int width, int height)
        {
            MapLayerName = mapLayerName;
            Width = width;
            Height = height;

            layer = new Tile[height * width];
        }

        public MapLayerData(string mlName, int w, int h, int tIndex, int tSet)
        {
            MapLayerName = mlName;
            Width = w;
            Height = h;

            layer = new Tile[h * w];

            Tile tile = new Tile(tIndex, tSet);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    SetTile(x, y, tile);
        }

        public void SetTile(int x, int y, Tile tile)
        {
            layer[y * Width + x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileSet)
        {
            layer[y * Width + x] = new Tile(tileIndex, tileSet);
        }

        public Tile GetTile(int x, int y)
        {
            return layer[y * Width + x];
        }
    }
}