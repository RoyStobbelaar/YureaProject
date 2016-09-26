using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary;
using XRpgLibrary.TileEngine;
using YureaProject.Components;
using YureaProject.GameStates;

namespace YureaProject.GameScreens.IngameScreens
{
    /// <summary>
    /// This screen is opened by pressing F1 (for the first party member) up to F4 (for the fourth party member)
    /// </summary>
    public class CharacterInfoScreen : BaseGameState
    {
        #region Fields & Properties Region

        Player player;
        Texture2D backgroundImage;

        public Player CurrentPlayer
        {
            get { return player; }
            set { player = value; }
        }

        #endregion


        #region Constructor Region

        public CharacterInfoScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            ContentManager Content = GameRef.Content;
            backgroundImage = Content.Load<Texture2D>(@"Backgrounds\Titlescreen");
        }

        #endregion
        #region Methods Region


        #endregion
        #region Virtual Methods region

        public override void Initialize()
        {
            base.Initialize();

        }

        /// <summary>
        /// Load screen layout
        /// </summary>
        protected override void LoadContent()
        {

        }

        /// <summary>
        /// Draw current player values
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            GameRef.spriteBatch.Begin();

            base.Draw(gameTime);

            /*Debug options*/

            GameRef.spriteBatch.Draw(backgroundImage, GameRef.gameScreen, Color.White);

            //ControlManager.Draw(GameRef.spriteBatch);

            GameRef.spriteBatch.End();
        }

        #endregion
    }
}
