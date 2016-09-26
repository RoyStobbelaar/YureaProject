using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XRpgLibrary;
using YureaProject.GameStates;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary.Controls;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace YureaProject.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        #region Fields & Properties

        PictureBox backgroundImage;
        PictureBox arrowImage;
        LinkLabel startGame;
        LinkLabel loadGame;
        LinkLabel exitGame;
        float maxItemWidth = 0f;

        #endregion

        #region Constructor

        public StartMenuScreen(Game game, GameStateManager manager) : base(game, manager)
        {

        }

        #endregion

        #region XNA Methods

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;

            backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Backgrounds\Titlescreen"), GameRef.gameScreen);
            ControlManager.Add(backgroundImage);

            Texture2D arrowTexture = Content.Load<Texture2D>(@"Gui\leftarrowUp");

            arrowImage = new PictureBox(
                arrowTexture, new Rectangle(0, 0, arrowTexture.Width, arrowTexture.Height));
            ControlManager.Add(arrowImage);

            startGame = new LinkLabel();
            startGame.Text = "The story begins";
            startGame.Size = startGame.SpriteFont.MeasureString(startGame.Text);
            startGame.Selected += new EventHandler(menuItem_Selected);

            ControlManager.Add(startGame);

            loadGame = new LinkLabel();
            loadGame.Text = "The story continues";
            loadGame.Size = loadGame.SpriteFont.MeasureString(loadGame.Text);
            loadGame.Selected +=menuItem_Selected;

            ControlManager.Add(loadGame);

            exitGame = new LinkLabel();
            exitGame.Text = "The story ends";
            exitGame.Size = exitGame.SpriteFont.MeasureString(exitGame.Text);
            exitGame.Selected += menuItem_Selected;

            ControlManager.Add(exitGame);

            ControlManager.NextControl();

            ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);
            Vector2 position = new Vector2(50, 200);

            foreach(Control c in ControlManager)
            {
                if(c is LinkLabel)
                {
                    if (c.Size.X > maxItemWidth)
                        maxItemWidth = c.Size.X;

                    c.Position = position;
                    position.Y += c.Size.Y + 5f;
                }
            }

            ControlManager_FocusChanged(startGame, null);
        }

        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f, control.Position.Y);
            arrowImage.SetPosition(position);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {
            if(sender == startGame)
            {
                Transition(ChangeType.Push, GameRef.characterGeneratorScreen);
                //StateManager.PushState(GameRef.characterGeneratorScreen);
            }
            if(sender == loadGame)
            {
                Transition(ChangeType.Push, GameRef.loadGameScreen);
                //StateManager.PushState(GameRef.gamePlayScreen);
            }
            if(sender == exitGame)
            {
                GameRef.Exit();
            }
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);

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

        #region Game State Method
        #endregion
    }
}
