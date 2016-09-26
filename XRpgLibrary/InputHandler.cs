using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace XRpgLibrary
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Field Region

        static KeyboardState keyboardState;
        static KeyboardState previousKeyboardState;

        #endregion

        #region Game Pad Region

        static GamePadState[] gamePadStates;
        static GamePadState[] previousGamePadStates;

        #endregion

        #region Property Region

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState PreviousKeyboardState
        {
            get { return PreviousKeyboardState; }
        }

        #endregion

        #region Game Pad Property Region

        public static GamePadState[] GamePadStates
        {
            get { return GamePadStates; }
        }

        public static GamePadState[] PreviousGamePadStates
        {
            get { return PreviousGamePadStates; }
        }

        #endregion

        #region Constructor Region

        public InputHandler(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            keyboardState = Keyboard.GetState();

            gamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);
        }

        #endregion

        #region XNA Methods

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            previousGamePadStates = (GamePadState[])gamePadStates.Clone();
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
                gamePadStates[(int)index] = GamePad.GetState(index);

            base.Update(gameTime);
        }

        #endregion

        #region General Method Region

        public static void Flush()
        {
            previousKeyboardState = keyboardState;
        }

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        #endregion

        #region Game Pad Region

        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonUp(button) &&
                previousGamePadStates[(int)index].IsButtonDown(button);
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(button) &&
                previousGamePadStates[(int)index].IsButtonUp(button);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(button);
        }

        #endregion
    }
}
