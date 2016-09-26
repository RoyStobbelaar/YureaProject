using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XRpgLibrary;
using YureaProject.GameStates;
using XRpgLibrary.TileEngine;
using Microsoft.Xna.Framework.Graphics;
using YureaProject.Components;
using XRpgLibrary.SpriteClasses;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary.WorldClasses;
using YureaProject.GameScreens.IngameScreens;

namespace YureaProject.GameScreens
{
    public enum IngameState { Ingame, CharacterInfo}
    public class GamePlayScreen : BaseGameState
    {

        #region Field & Properties

        Engine engine = new Engine(32, 32);
        static Player player;
        static World world;
        IngameState currentState;

        CharacterInfoScreen characterInfo;

        public static Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public static World World
        {
            get { return world; }
            set { world = value; }
        }

        #endregion

        #region Constructor Region

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        #endregion

        #region XNA Methods

        public override void Initialize()
        {
            base.Initialize();
            currentState = IngameState.Ingame;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (currentState == IngameState.Ingame)
            {
                world.Update(gameTime);
                player.Update(gameTime);
            }
            else
            {
                if (characterInfo == null)
                {
                    characterInfo = new CharacterInfoScreen(GameRef,StateManager);
                }
                characterInfo.Update(gameTime);
                characterInfo.Draw(gameTime);
            }

            if (InputHandler.KeyPressed(Keys.F1))
            {
                if (currentState == IngameState.Ingame)
                    currentState = IngameState.CharacterInfo;
                else
                    currentState = IngameState.Ingame;
            }
            

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, player.Camera.Transformation);

            base.Draw(gameTime);

            world.DrawLevel(gameTime,GameRef.spriteBatch, player.Camera);
            player.Draw(gameTime, GameRef.spriteBatch);

            /*Draw UI*/

            GameRef.spriteBatch.Draw(player.Character.Entity.Portrait, new Rectangle((int)player.Camera.Position.X, (int)player.Camera.Position.Y, 96, 96), Color.White);

            GameRef.spriteBatch.End();
        }

        #endregion

        #region Abstract Methods region

        #endregion

    }
}
