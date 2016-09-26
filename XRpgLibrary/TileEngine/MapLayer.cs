using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.WorldClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.TileEngine
{
    public class MapLayer : ILayer
    {
        #region Field & Properties

        Tile[,] map;
        Dictionary<string, Point> linkedTiles;

        public int Width
        {
            get { return map.GetLength(1); }
        }

        public int Height
        {
            get { return map.GetLength(0); }
        }

        public Dictionary<string, Point> LinkedTiles
        {
            get { return linkedTiles; }
        }

        #endregion

        #region Constructor Region

        public MapLayer(Tile[,] map)
        {
            this.map = (Tile[,])map.Clone();
            linkedTiles = new Dictionary<string, Point>();
        }

        public MapLayer(int width, int height)
        {
            linkedTiles = new Dictionary<string, Point>();
            map = new Tile[height, width];

            for(int y=0; y< height; y++)
            {
                for(int x=0; x < width; x++)
                {
                    map[y, x] = new Tile(0, 0);
                }
            }
        }

        #endregion

        #region Method Region

        public Tile GetTile(int x, int y)
        {
            return map[y, x];
        }

        public void SetTile(int x, int y, Tile tile)
        {
            map[y, x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileset)
        {
            map[y, x] = new Tile(tileIndex, tileset);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, List<TileSet> tilesets)
        {
            Point cameraPoint = Engine.VectorToCell(camera.Position * (1 / camera.Zoom));
            Point viewPoint = Engine.VectorToCell(new Vector2((camera.Position.X + camera.ViewportRectangle.Width) * (1 / camera.Zoom),
                (camera.Position.Y + camera.ViewportRectangle.Height) * (1 / camera.Zoom)));

            Point min = new Point();
            Point max = new Point();

            min.X = Math.Max(0, cameraPoint.X - 1);
            min.Y = Math.Max(0, cameraPoint.Y - 1);
            max.X = Math.Min(viewPoint.X + 1, Width);
            max.Y = Math.Min(viewPoint.Y + 1, Height);

            Rectangle destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
            Tile tile;

            for(int y = min.Y; y< max.Y; y++)
            {
                destination.Y = y * Engine.TileHeight;

                for(int x = min.X;x < max.X; x++)
                {
                    tile = GetTile(x, y);

                    if (tile.TileIndex == -1 || tile.Tileset == -1)
                        continue;

                    destination.X = x * Engine.TileWidth;

                    spriteBatch.Draw(tilesets[tile.Tileset].Texture, destination, tilesets[tile.Tileset].SourceRectangles[tile.TileIndex], Color.White);
                }
            }
        }

        public static MapLayer FromMapLayerData(MapLayerData data)
        {
            MapLayer layer = new MapLayer(data.Width, data.Height);
            layer.linkedTiles = data.LinkedTiles;

            for(int y=0;y<data.Height;y++)
                for(int x=0; x< data.Width; x++)
                {
                    layer.SetTile(x, y, data.GetTile(x, y).TileIndex, data.GetTile(x, y).TileSetIndex);
                }

            return layer;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void SetLink(int tileX, int tileY, string nextArea)
        {
            try
            {
                linkedTiles.Add(nextArea, new Point(tileX, tileY));
            }
            catch
            {
                Console.WriteLine("Already added");
            }
        }

        #endregion

    }
}
