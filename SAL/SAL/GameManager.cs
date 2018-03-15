/**
 * Spencer Chang
 * 15 March 2018
 * 
 * A singleton handler for different instances of screens. Decides which instance of
 * a GameState should be updated and drawn.
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL
{
    /// <summary>
    /// Seperates different game states and draws them accordingly.
    /// </summary>
    public class GameManager
    {
        #region Singleton Initialization
        private static GameManager inst;

        /// <summary>
        /// Creates a new instance of the <c>Screenmanager</c>.
        /// </summary>
        private GameManager()
        {
            state = new GameState();
        }
        
        /// <summary>
        /// Returns the singleton instance of the screen manager.
        /// </summary>
        /// <returns></returns>
        public static GameManager GetInstance()
        {
            // initializes the screenmanager on the first time calling this method.
            if (inst == null)
            {
                inst = new GameManager();
            }

            return inst;
        }
        #endregion

        private GameState state;

        /// <summary>
        /// The current instance of the screen.
        /// </summary>
        public GameState State
        {
            get { return state; }
        }

        /// <summary>
        /// Initializes the GameManager's content-related components.
        /// </summary>
        public void Initialize()
        {
            
        }

        /// <summary>
        /// Updates the GameManager and the current instance of the game state.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }

        /// <summary>
        /// Draws the current instance to the screen.
        /// </summary>
        /// <param name="spriteBatch">Draws the content on the screen.</param>
        /// <param name="graphics">Allows access to graphical properties.</param>
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            state.Draw(spriteBatch, graphics);
        }
    }
}
