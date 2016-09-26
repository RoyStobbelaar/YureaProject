using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XRpgLibrary;
using YureaProject.GameStates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using XRpgLibrary.Controls;

namespace YureaProject.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        #region Field Region

        Texture2D backgroundImage;
        LinkLabel startLabel;
        #endregion

        #region Constructor Region

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {

        }

        #endregion

        #region XNA Method Region

        protected override void LoadContent()
        {
            ContentManager Content = GameRef.Content;
            backgroundImage = Content.Load<Texture2D>(@"Backgrounds\Titlescreen");
            base.LoadContent();

            startLabel = new LinkLabel();
            startLabel.Position = new Vector2(50, 200);
            startLabel.Text = "Press <enter> to start";
            startLabel.Color = Color.White;
            startLabel.TapStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(StartLabel_Selected);

            ControlManager.Add(startLabel);
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime,PlayerIndex.One);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.spriteBatch.Begin();
            base.Draw(gameTime);
            GameRef.spriteBatch.Draw(backgroundImage, GameRef.gameScreen, Color.White);

            ControlManager.Draw(GameRef.spriteBatch);

            GameRef.spriteBatch.End();
        }

        #endregion

        #region TitleScreen Methods

        private void StartLabel_Selected(object sender, EventArgs e)
        {
            Transition(ChangeType.Push, GameRef.startMenuScreen);
            //StateManager.PushState(GameRef.startMenuScreen);
        }

        #endregion
    }
}