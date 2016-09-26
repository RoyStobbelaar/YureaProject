using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.CharacterClasses;
using XRpgLibrary.ItemClasses;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.WorldClasses
{
    public class Level
    {
        #region Fields & Properties

        readonly TileMap map;
        private string levelName;
        readonly List<Character> characters;
        readonly List<ItemSprite> chests;

        public TileMap Map
        {
            get { return map; }
        }

        public List<Character> Characters
        {
            get { return characters; }
        }

        public List<ItemSprite> Chests
        {
            get { return chests; }
        }

        public string LevelName
        {
            get { return levelName; }
            set { levelName = value; }
        }

        #endregion

        #region Constructor Region

        public Level(TileMap tileMap)
        {
            map = tileMap;
            characters = new List<Character>();
            chests = new List<ItemSprite>();
        }

        public Level(string mapName)
        {
            /*map = Deserialize(mapName)*/

            characters = new List<Character>();
            chests = new List<ItemSprite>();
        }

        #endregion

        #region Methods Region

        public void Update(GameTime gameTime)
        {
            foreach (Character character in characters)
                character.Update(gameTime);

            foreach (ItemSprite sprite in chests)
                sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime,SpriteBatch spriteBatch, Camera camera)
        {
            map.Draw(spriteBatch, camera);

            foreach (Character character in characters)
                character.Draw(gameTime, spriteBatch);

            foreach (ItemSprite sprite in chests)
                sprite.Draw(gameTime, spriteBatch);
        }

        #endregion

    }
}
