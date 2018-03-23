/**
 * Spencer Chang
 * 15 March 2018
 * 
 * A parent class for game instances. (Think of this object as different states of the game)
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL
{
    /// <summary>
    /// Parent class for different states of the game.
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Loads game-necessary assets. A different instance of a contentmanager is necessary
        /// for easier organization of unloading assets.
        /// </summary>
        public ContentManager Content
        {
            get;
            private set;
        }

        private SomeonesAssemblyLine GameInstance;

        /// <summary>
        /// Creates a new instance of the <c>GameState</c>.
        /// </summary>
        public GameState(SomeonesAssemblyLine inst)
        {
            GameInstance = inst;
        }

        /// <summary>
        /// The game instance of the game.
        /// </summary>
        /// <returns></returns>
        public SomeonesAssemblyLine GetInstance()
        {
            return GameInstance;
        }

        /// <summary>
        /// Initializes this instance of the <c>GameState</c>.
        /// </summary>
        /// <param name="Content">Provides a way to load assets.</param>
        public void Initialize(ContentManager Content)
        {
            // initializes the contentmanager within the folder "Content"
            this.Content = new ContentManager(Content.ServiceProvider, "Content");

            Load();
        }

        /// <summary>
        /// Unloads the content from this instance of the <c>GameState</c>.
        /// </summary>
        public virtual void Unload()
        {
            // unloads this instance of the content manager
            Content.Unload();
        }

        /// <summary>
        /// Loads the game state's assets after the contentmanager's initialization.
        /// </summary>
        public virtual void Load()
        {

        }

        /// <summary>
        /// Updates this instance of the <c>GameState</c>.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the <c>GameState</c> and all of its contents.
        /// </summary>
        /// <param name="spriteBatch">Draws the content to the screen.</param>
        /// <param name="graphics">Allows access to graphical properties.</param>
        public virtual void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {

        }

    }
}
