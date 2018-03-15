﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Author: 		Spencer Chang
/// Date Created:	November 27, 2017
/// </summary>
namespace SAL.Etc
{
    /// <summary>
    /// Calculates and counts the frame rate of the game's display.
    /// </summary>
    public class FPSCounter : DrawableGameComponent
    {
        #region Fields
        private int frameCount, frameRate;
        private ContentManager Content;
        private SpriteBatch spriteBatch;
        private float elapsedTimer;
        private SpriteFont font;
        private CornerPosition position;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of FPSCounter
        /// </summary>
        public FPSCounter(Game game, CornerPosition position) 
            : base (game)
        {
            this.position = position;
            frameCount = 0;
            elapsedTimer = 0f;
            Content = new ContentManager(game.Content.ServiceProvider, "Content");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the FPSCounter.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            font = Content.Load<SpriteFont>("Temp Font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Updates the game logic of the component.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsedTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            if (elapsedTimer >= 1000f)
            {
                elapsedTimer = 0f;
                frameRate = frameCount;
                frameCount = 0;
            }
        }

        /// <summary>
        /// Draws the frames to the screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            string text = "FPS: " + frameRate + "\n";
            text += "MouseX: " + Mouse.GetState().X + "\n";
            text += "MouseY: " + Mouse.GetState().Y + "\n";

            spriteBatch.Begin();

            int width = Game.GraphicsDevice.Viewport.Width;
            int height = Game.GraphicsDevice.Viewport.Height;
            int x = (int)font.MeasureString(text).X;
            Vector2 pos = Vector2.Zero;

            switch (position)
            {
                case CornerPosition.TOP_RIGHT:
                    pos = new Vector2(width - 10 - x, 10);
                    break;

                case CornerPosition.TOP_LEFT:
                    pos = new Vector2(10, 10);
                    break;
            }

            spriteBatch.DrawString(font, text, pos + new Vector2(1, 1), Color.Black * 0.3f);
            spriteBatch.DrawString(font, text, pos, Color.White);

            spriteBatch.End();

            frameCount++;

            base.Draw(gameTime);
        }
        #endregion
    }
}
