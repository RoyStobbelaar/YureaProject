using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XRpgLibrary;
using YureaProject.GameStates;
using XRpgLibrary.Controls;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.SpriteClasses;
using YureaProject.Components;
using XRpgLibrary.TileEngine;
using XRpgLibrary.WorldClasses;
using XRpgLibrary.CharacterClasses;
using RpgLibrary.CharacterClasses;

namespace YureaProject.GameScreens
{
    public class LoadGameScreen : BaseGameState
    {

        #region Fields & Property

        PictureBox backgroundImage;
        ListBox loadListBox;
        LinkLabel loadLinkLabel;
        LinkLabel exitLinkLabel;

        #endregion

        #region Contructor Region

        public LoadGameScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        #endregion

        #region Method Region

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;

            backgroundImage = new PictureBox(Content.Load<Texture2D>(@"Backgrounds\Titlescreen"), GameRef.gameScreen);
            ControlManager.Add(backgroundImage);

            loadLinkLabel = new LinkLabel();
            loadLinkLabel.Text = "Select game";
            loadLinkLabel.Position = new Vector2(50, 100);
            loadLinkLabel.Selected += new EventHandler(loadLinkLabel_Selected);
            ControlManager.Add(loadLinkLabel);

            exitLinkLabel = new LinkLabel();
            exitLinkLabel.Text = "Back";
            exitLinkLabel.Position = new Vector2(50, 100 + exitLinkLabel.SpriteFont.LineSpacing);
            exitLinkLabel.Selected += new EventHandler(exitLinkLabel_Selected);
            ControlManager.Add(exitLinkLabel);

            loadListBox = new ListBox(Content.Load<Texture2D>(@"Gui\listBoxImage"), Content.Load<Texture2D>(@"Gui\rightarrowUp"));
            loadListBox.Position = new Vector2(400, 100);
            loadListBox.Selected += new EventHandler(loadListBox_Selected);
            loadListBox.Leave += new EventHandler(loadListBox_Leave);

            for (int i = 0; i < 20; i++)
                loadListBox.Items.Add("Game number: " + i.ToString());
            ControlManager.Add(loadListBox);

            ControlManager.NextControl();
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

        void loadListBox_Leave(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = true;
        }

        void loadLinkLabel_Selected(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = false;
            loadLinkLabel.HasFocus = false;
            loadListBox.HasFocus = true;
        }

        void loadListBox_Selected(object sender, EventArgs e)
        {
            loadLinkLabel.HasFocus = true;
            loadListBox.HasFocus = false;
            ControlManager.AcceptInput = true;

            Transition(ChangeType.Change, GameRef.gamePlayScreen);
            //StateManager.ChangeState(GameRef.gamePlayScreen);
            CreatePlayer();
            CreateWorld();
        }

        void exitLinkLabel_Selected(object sender, EventArgs e)
        {
            Transition(ChangeType.Pop, null);
            //StateManager.PopState();
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

            AnimatedSprite sprite = new AnimatedSprite(GameRef.Content.Load<Texture2D>(@"PlayerSprites\malefighter"),animations);
            Entity entity = new Entity("Ashino", DataManager.EntityData["Fighter"], EntityGender.Male, EntityType.Character);
            Character character = new Character(entity, sprite);

            GamePlayScreen.Player = new Player(GameRef, character);
        }

        private void CreateWorld()
        {

            Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\Outside_A2");
            TileSet tileset1 = new TileSet(tilesetTexture, 16, 12, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\Outside_B");
            TileSet tileset2 = new TileSet(tilesetTexture, 16, 16, 32, 32);

            MapLayer layer = new MapLayer(100, 100);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0, 0);
                    layer.SetTile(x, y, tile);
                }
            }

            MapLayer splatter = new MapLayer(100, 100);
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                int index = random.Next(176, 181);
                Tile tile = new Tile(index, 1);
                splatter.SetTile(x, y, tile);
            }

            /*Create forest*/
            splatter.SetTile(3, 0, new Tile(224, 1));
            splatter.SetTile(3, 1, new Tile(240, 1));

            splatter.SetTile(4, 0, new Tile(226, 1));
            splatter.SetTile(5, 0, new Tile(227, 1));
            splatter.SetTile(4, 1, new Tile(242, 1));
            splatter.SetTile(5, 1, new Tile(243, 1));

            splatter.SetTile(6, 0, new Tile(225, 1));
            splatter.SetTile(6, 1, new Tile(241, 1));

            splatter.SetTile(5, 2, new Tile(241, 1));
            splatter.SetTile(4, 2, new Tile(240, 1));

            TileMap map = new TileMap(tileset1, layer);
            map.AddTileset(tileset2);
            map.AddLayer(splatter);

            Level level = new Level(map);

            World world = new World(GameRef, GameRef.gameScreen);
            world.Levels.Add(level);
            world.CurrentLevel = level;

            GamePlayScreen.World = world;
        }


        #endregion


    }
}
