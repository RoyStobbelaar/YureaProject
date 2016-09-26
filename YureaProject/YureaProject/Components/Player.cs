using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary;
using XRpgLibrary.CharacterClasses;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.TileEngine;
using YureaProject.GameScreens;

namespace YureaProject.Components
{
    public class Player
    {
        #region Fields & Properties

        Camera camera;
        Game1 gameRef;
        readonly Character character;
        Vector2 previousMapPosition;

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        public AnimatedSprite Sprite
        {
            get { return character.Sprite; }
        }

        public Character Character
        {
            get { return character; }
        }

        public Vector2 PreviousMapPosition
        {
            get { return previousMapPosition; }
            set { previousMapPosition = value; }
        }

        #endregion

        #region Constructor Region

        public Player(Game game, Character character)
        {
            gameRef = (Game1)game;
            camera = new Camera(gameRef.gameScreen);
            this.character = character;
            this.Sprite.Position = new Vector2(5, 5);
        }

        #endregion

        #region Methods Region

        public void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
            Sprite.Update(gameTime);

            if(InputHandler.KeyReleased(Keys.PageUp) || InputHandler.ButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
            {
                camera.ZoomIn();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }
            else if (InputHandler.KeyReleased(Keys.PageDown) || InputHandler.ButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
            {
                camera.ZoomOut();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }

            Vector2 motion = new Vector2();

            if(InputHandler.KeyDown(Keys.W) || InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }
            else if (InputHandler.KeyDown(Keys.S) || InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }
            if (InputHandler.KeyDown(Keys.A) || InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }
            else if (InputHandler.KeyDown(Keys.D) || InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            if(motion != Vector2.Zero)
            {
                UpdatePosition(gameTime, motion);

                //Sprite.IsAnimating = true;
                //motion.Normalize();

                //Sprite.Position += motion * Sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //Sprite.LockToMap();

                //if (camera.CameraMode == CameraMode.Follow)
                //    camera.LockToSprite(Sprite);
            }
            else
            {
                Sprite.IsAnimating = false;
            }

            if (InputHandler.KeyReleased(Keys.F) || InputHandler.ButtonReleased(Buttons.RightStick, PlayerIndex.One))
            {
                camera.ToggleCameraMode();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }

            if(camera.CameraMode != CameraMode.Follow)
            {
                if(InputHandler.KeyReleased(Keys.C) || InputHandler.ButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                {
                    camera.LockToSprite(Sprite);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            character.Draw(gameTime, spriteBatch);
        }

        private void UpdatePosition(GameTime gameTime, Vector2 motion)
        {
            Sprite.IsAnimating = true;

            Vector2 distance = motion * Sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 next = distance + Sprite.Position;

            Rectangle playerRect = new Rectangle((int)next.X + CollisionLayer.CollisionRadius, (int)next.Y + CollisionLayer.CollisionRadius, Engine.TileWidth - CollisionLayer.CollisionRadius, Engine.TileHeight - CollisionLayer.CollisionRadius);

            foreach (Point p in GamePlayScreen.World.CurrentMap.CollisionLayer.Collisions.Keys)
            {
                Rectangle r = new Rectangle(p.X * Engine.TileWidth + CollisionLayer.CollisionRadius, p.Y * Engine.TileHeight + CollisionLayer.CollisionRadius, Engine.TileWidth - CollisionLayer.CollisionRadius, Engine.TileHeight - CollisionLayer.CollisionRadius);

                if (r.Intersects(playerRect))
                {
                    if (GamePlayScreen.World.CurrentMap.LinkedTiles.Values.Contains(p))
                    {
                        Console.WriteLine("Next area");
                        GamePlayScreen.World.NewArea(GamePlayScreen.World.CurrentMap.LinkedTiles.First(point => point.Value == p).Key);

                        if (previousMapPosition != null)
                            this.Sprite.Position = previousMapPosition;

                        previousMapPosition = new Vector2((p.X+1) * Engine.TileWidth, p.Y * Engine.TileHeight);
                        Sprite.LockToMap();

                        if (camera.CameraMode == CameraMode.Follow)
                            camera.LockToSprite(Sprite);
                    }

                    Console.WriteLine("COLLISION");
                    //Collision
                    return;
                }
            }



            Sprite.Position = next;
            Sprite.LockToMap();

            if (camera.CameraMode == CameraMode.Follow)
                camera.LockToSprite(Sprite);
        }

        #endregion


    }
}
