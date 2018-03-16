/**
 * Spencer Chang
 * 15 March 2018
 * 
 * The main state of the game. This is where most of the game components will function: Draw
 * and Update.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SAL.GameStates
{
    /// <summary>
    /// The main game state for the game instance.
    /// </summary>
    public class MainState : GameState
    {
        
        /// <summary>
        /// Creates and initializes a new instance of <c>MainState</c>
        /// </summary>
        public MainState() 
            : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the main game state.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="graphics"></param>
        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            base.Draw(spriteBatch, graphics);
        }
    }
}
