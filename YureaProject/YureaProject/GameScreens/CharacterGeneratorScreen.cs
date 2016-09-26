using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XRpgLibrary;
using YureaProject.GameStates;
using XRpgLibrary.Controls;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.SpriteClasses;
using YureaProject.Components;
using XRpgLibrary.TileEngine;
using XRpgLibrary.WorldClasses;
using RpgLibrary.ItemClasses;
using XRpgLibrary.ItemClasses;
using XRpgLibrary.CharacterClasses;
using RpgLibrary.SkillClasses;
using RpgLibrary.CharacterClasses;
using System.IO;
using System.Reflection;

namespace YureaProject.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        #region Fields & Properties

        LeftRightSelector genderSelector;
        LeftRightSelector classSelector;
        PictureBox portraitImage;
        PictureBox backgroundImage;
        PictureBox characterImage;

        string[] genderItems = { "Male", "Female" };
        //string[] classItems = { "Fighter", "Rogue", "Mage" };
        string[] classItems;

        Texture2D[,] portraitImages;
        Texture2D[,] characterImages;
        Texture2D containers;

        public string SelectedGender
        {
            get { return genderSelector.Selecteditem; }
        }

        public string SelectedClass
        {
            get { return classSelector.Selecteditem; }
        }

        #endregion

        public CharacterGeneratorScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        #region XNA Methods Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            classItems = new string[DataManager.EntityData.Count];

            int counter = 0;

            foreach (string className in DataManager.EntityData.Keys)
            {
                classItems[counter] = className;
                counter++;
            }

            LoadImages();
            CreateControls();
            containers = Game.Content.Load<Texture2D>(@"ObjectSprites\containers");
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.spriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.spriteBatch);

            GameRef.spriteBatch.End();
        }

        #endregion

        #region Method Region

        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>(@"Gui\leftarrowUp");
            Texture2D rightTexture = Game.Content.Load<Texture2D>(@"Gui\rightarrowUp");
            Texture2D stopTexture = Game.Content.Load<Texture2D>(@"Gui\StopBar");

            backgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\Titlescreen"), GameRef.gameScreen);
            ControlManager.Add(backgroundImage);

            Label label1 = new Label();

            label1.Text = "Create your hero";
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2((GameRef.Window.ClientBounds.Width - label1.Size.X) / 6, 170);
            ControlManager.Add(label1);

            genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            genderSelector.SetItems(genderItems, 125);
            genderSelector.Position = new Vector2(label1.Position.X, 220);
            genderSelector.SelectionChanged += new EventHandler(selectedChanged);
            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            classSelector.SetItems(classItems, 125);
            classSelector.Position = new Vector2(label1.Position.X, 270);
            classSelector.SelectionChanged += selectedChanged;
            ControlManager.Add(classSelector);

            LinkLabel linklabel1 = new LinkLabel();
            linklabel1.Text = "Accept your hero?";
            linklabel1.Position = new Vector2(label1.Position.X, 320);
            linklabel1.Selected += new EventHandler(linkLabel1_Selected);

            ControlManager.Add(linklabel1);

            characterImage = new PictureBox(characterImages[0, 0], new Rectangle(500, 200, 64, 64), new Rectangle(0, 0, 32, 32));

            portraitImage = new PictureBox(portraitImages[0, 0], new Rectangle(500, 300, 96, 96), new Rectangle(0, 0, 96, 96));

            ControlManager.Add(characterImage);
            ControlManager.Add(portraitImage);

            ControlManager.NextControl();

        }

        private void LoadImages()
        {
            characterImages = new Texture2D[genderItems.Length, classItems.Length];
            portraitImages = new Texture2D[genderItems.Length, classItems.Length];
            for (int i = 0; i < genderItems.Length; i++)
            {
                for (int j = 0; j < classItems.Length; j++)
                {
                    characterImages[i, j] = Game.Content.Load<Texture2D>(@"PlayerSprites\" + genderItems[i] + classItems[j]);
                    portraitImages[i, j] = Game.Content.Load<Texture2D>(@"Portraits\" + genderItems[i] + classItems[j]);
                }
            }

        }

        void linkLabel1_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            CreatePlayer();
            CreateWorld();

            GameRef.skillScreen.SkillPoints = 10;
            Transition(ChangeType.Change, GameRef.skillScreen);
            GameRef.skillScreen.SetTarget(GamePlayScreen.Player.Character);
            //StateManager.ChangeState(GameRef.skillScreen);


            //StateManager.PopState();
            //StateManager.PushState(GameRef.gamePlayScreen);
        }

        private void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);
            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);
            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);
            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            AnimatedSprite sprite = new AnimatedSprite(characterImages[genderSelector.SelectedIndex, classSelector.SelectedIndex], animations);
            EntityGender gender = EntityGender.Male;

            if (genderSelector.SelectedIndex == 1)
                gender = EntityGender.Female;

            Entity entity = new Entity("Pat", DataManager.EntityData[classSelector.Selecteditem], gender, EntityType.Character);
            entity.Portrait = portraitImages[genderSelector.SelectedIndex, classSelector.SelectedIndex];

            foreach (string s in DataManager.SkillData.Keys)
            {
                Skill skill = Skill.FromSkillData(DataManager.SkillData[s]);
                entity.Skills.Add(s, skill);
            }

            Character character = new Character(entity, sprite);

            GamePlayScreen.Player = new Player(GameRef, character);
            GamePlayScreen.Player.Sprite.Position = new Vector2(5, 5);
        }

        private void CreateWorld()
        {

            RpgLibrary.WorldClasses.LevelData newLevel = null;
            RpgLibrary.WorldClasses.MapData mapData = null;

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                newLevel = XnaSerializer.Deserialize<RpgLibrary.WorldClasses.LevelData>(path + @"..\..\..\..\..\YureaProjectContent\Game\Levels\TestQuest.xml");
                mapData = XnaSerializer.Deserialize<RpgLibrary.WorldClasses.MapData>(path + @"..\..\..\..\..\YureaProjectContent\Game\Levels\Maps\" + newLevel.MapName + ".xml");
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
            

            Level level = new Level(map);
            level.LevelName = newLevel.LevelName;

            ChestData chestData = Game.Content.Load<ChestData>(@"Game\Chests\Silver Chest");
            Chest chest = new Chest(chestData);

            BaseSprite chestSprite = new BaseSprite(containers, new Rectangle(0, 0, 32, 32), new Point(20, 20));
           
            ItemSprite itemSprite = new ItemSprite(chest, chestSprite);
            level.Chests.Add(itemSprite);

            World world = new World(GameRef, GameRef.gameScreen);
            world.Levels.Add(level);
            world.CurrentLevel = level;

            GamePlayScreen.World = world;
        }

        void selectedChanged(object sender, EventArgs e)
        {
            characterImage.Image = characterImages[genderSelector.SelectedIndex, classSelector.SelectedIndex];
            portraitImage.Image = portraitImages[genderSelector.SelectedIndex, classSelector.SelectedIndex];
        }

        #endregion
    }
}
