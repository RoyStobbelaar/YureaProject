using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRpgLibrary.TileEngine
{
    public class TileMap
    {
        #region Field & Properties

        List<TileSet> tilesets;
        List<ILayer> mapLayers;
        CollisionLayer collisionLayer;

        static int mapWidth;
        static int mapHeight;

        public static int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; }
        }

        public static int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }

        public CollisionLayer CollisionLayer
        {
            get { return collisionLayer; }
        }

        public Dictionary<string, Point> LinkedTiles
        {
            get {
                foreach(ILayer layer in mapLayers)
                {
                    if(((MapLayer)layer).LinkedTiles.Count != 0)
                    {
                        return ((MapLayer)layer).LinkedTiles;
                    }
                }
                return new Dictionary<string, Point>();
            }
        }

        #endregion

        #region Constructor Region

        public TileMap(List<TileSet>tilesets, MapLayer baseLayer, MapLayer buildingLayer, MapLayer splatterLayer, CollisionLayer collisionLayer)
        {

            this.tilesets = tilesets;
            this.mapLayers = new List<ILayer>();
            this.mapLayers.Add(baseLayer);
            this.collisionLayer = collisionLayer;

            AddLayer(buildingLayer);
            AddLayer(splatterLayer);

            mapWidth = baseLayer.Width;
            mapHeight = baseLayer.Height;
            
        }

        public TileMap(TileSet tileset, MapLayer layer)
        {
            tilesets = new List<TileSet>();
            tilesets.Add(tileset);

            collisionLayer = new CollisionLayer();

            mapLayers = new List<ILayer>();
            mapLayers.Add(layer);

            mapWidth = layer.Width;
            mapHeight = layer.Height;
        }

        public TileMap(int width, int height)
        {
            tilesets = new List<TileSet>();

            collisionLayer = new CollisionLayer();

            mapLayers = new List<ILayer>();

            mapWidth = width;
            mapHeight = height;
        }

        #endregion

        #region Method Region

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach(MapLayer layer in mapLayers)
            {
                layer.Draw(spriteBatch, camera, tilesets);
            }

            /*Debug options*/

            //Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 32, 32);

            //Color[] data = new Color[32 * 32];
            //for (int i = 0; i < data.Length; ++i) data[i] = Color.Red;
            //rect.SetData(data);

            //foreach (Point collisionPoint in collisionLayer.Collisions.Keys)
            //{
            //    spriteBatch.Draw(rect, new Vector2(collisionPoint.X * Engine.TileWidth, collisionPoint.Y * Engine.TileHeight), Color.White);
            //}
        }

        public void Update(GameTime gameTime)
        {
            foreach(ILayer layer in mapLayers)
            {
                layer.Update(gameTime);
            }
        }

        public void AddLayer(MapLayer layer)
        {
            if (layer is MapLayer)
            {
                if (!(((MapLayer)layer).Width == mapWidth && ((MapLayer)layer).Height == mapHeight))
                    throw new Exception("Map layer size exception");
            }
            mapLayers.Add(layer);
        }

        public void AddTileset(TileSet tileset)
        {
            tilesets.Add(tileset);
        }

        #endregion
    }
}
