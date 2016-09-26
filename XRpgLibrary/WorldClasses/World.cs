using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.ItemClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using XRpgLibrary.ItemClasses;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.WorldClasses
{
    public class World : DrawableGameComponent
    {

        #region Fields & Properties

        Rectangle screenRect;
        public Rectangle ScreenRectangle
        {
            get { return screenRect; }
        }

        ItemManager itemManager = new ItemManager();

        readonly List<Level> levels = new List<Level>();

        public List<Level> Levels
        {
            get { return levels; }
        }

        Level currentLevel;

        public Level CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        /*
        int currentLevel = -1;
        public int CurrentLevel
        {
            get { return currentLevel; }
            set
            {
                if (value < 0 || value >= levels.Count)
                    throw new IndexOutOfRangeException();

                if (levels[value] == null)
                    throw new NullReferenceException();

                currentLevel = value;
            }
        }
        */

        public TileMap CurrentMap
        {
            get { return currentLevel.Map; }
            //get { return levels[currentLevel].Map; }
        }

        //public Dictionary<Point, string> GetLinkedTiles
        //{
        //    get { return }
        //}

        #endregion

        #region Constructor

        public World(Game game, Rectangle screenRectangle):base(game)
        {
            screenRect = screenRectangle;
        }

        #endregion

        #region Methods Region

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void DrawLevel(GameTime gameTime,SpriteBatch spriteBatch, Camera camera)
        {
            currentLevel.Draw(gameTime, spriteBatch, camera);
            //levels[currentLevel].Draw(gameTime,spriteBatch, camera);
        }

        /// <summary>
        /// Change current level
        /// </summary>
        /// <param name="newLevelName"></param>
        public void NewArea(string newLevelName)
        {
            //foreach (Level level in levels)
                //if (level.LevelName == newLevelName)
                //{
                    RpgLibrary.WorldClasses.MapData mapData = null;

                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    try
                    {
                        mapData = Deserialize<RpgLibrary.WorldClasses.MapData>(path + @"..\..\..\..\..\YureaProjectContent\Game\Levels\Maps\" + newLevelName + ".xml");
                    }
                    catch (Exception ex)
                    {
                        return;
                    }

                    List<TileSet> tileSets = new List<TileSet>();
                    List<ILayer> layers = new List<ILayer>();
                    List<Point> collisionPoints = new List<Point>();
                    TileMap map = new TileMap(100, 100);
                    TileSet levelTileSet;

                    foreach (RpgLibrary.WorldClasses.TilesetData tileset in mapData.Tilesets)
                    {
                        /*Add tilesets to level*/
                        string fileName = Path.GetFileNameWithoutExtension(tileset.TilesetImageName);
                        Texture2D tilesetImage = Game.Content.Load<Texture2D>(@"Tilesets\" + fileName);
                        levelTileSet = new TileSet(tilesetImage, tileset.TilesWide, tileset.Tileshigh, tileset.TileWidthInPixels, tileset.TileHeightInPixels);
                        tileSets.Add(levelTileSet);
                    }

                    int layerCount = 0;
                    foreach (RpgLibrary.WorldClasses.MapLayerData l in mapData.Layers)
                    {
                        layers.Add(MapLayer.FromMapLayerData(l));
                        if (l.MapLayerName == "CollisionLayer")
                        {
                            /*Add collision to map*/
                            CollisionLayer collisionLayer = new CollisionLayer();
                            for (int y = 0; y < l.Height; y++)
                            {
                                for (int x = 0; x < l.Width; x++)
                                {
                                    RpgLibrary.WorldClasses.Tile collisiontile = l.GetTile(x, y);
                                    if (collisiontile.TileIndex != 0 && collisiontile.TileSetIndex != 0)
                                    {
                                        collisionPoints.Add(new Point(x, y));
                                    }
                                }
                            }
                        }
                    }

                    map = new TileMap(tileSets[0], (MapLayer)layers[0]);

                    for (int i = 1; i < tileSets.Count; i++)
                        map.AddTileset(tileSets[i]);

                    for (int i = 1; i < layers.Count; i++)
                    {
                        map.AddLayer((MapLayer)layers[i]);
                    }

                    foreach (Point collisionPoint in collisionPoints)
                        map.CollisionLayer.Collisions.Add(collisionPoint, CollisionType.Impassable);

                    Level newLevel = new Level(map);

                    currentLevel = newLevel;

            

                //}
        }

        static T Deserialize<T>(string fileName)
        {
            T data;

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    data = IntermediateSerializer.Deserialize<T>(reader, null);
                }
            }
            return data;
        }

        #endregion

    }
}
