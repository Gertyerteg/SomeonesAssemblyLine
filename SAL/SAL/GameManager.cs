/**
 * Spencer Chang
 * 15 March 2018
 * 
 * A singleton handler for different instances of screens. Decides which instance of
 * a GameState should be updated and drawn.
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SAL.GameStates;
using System;
using System.Collections.Generic;
using System.IO;
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
        private ContentManager Content;

        /// <summary>
        /// The library of all assets in the game.
        /// </summary>
        public Dictionary<string, Texture2D> Assets
        {
            get;
            private set;
        }

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
        public void Initialize(SomeonesAssemblyLine line)
        {
            Content = new ContentManager(line.Content.ServiceProvider, "Content");
            state = new MainState(line);
            Assets = new Dictionary<string, Texture2D>();

            RecursiveLoad("Content/");
            state.Initialize(Content);
            state.Load();
        }
        /// <summary>
        /// Adds a texture to the library.
        /// </summary>
        /// <param name="path"></param>
        public void LoadTexture(string path)
        {
            Assets.Add(path, Content.Load<Texture2D>(path));
        }

        /// <summary>
        /// Returns a texture from the library.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Texture2D GetTexture(string path)
        {
            Assets.TryGetValue(path, out Texture2D texture);

            while (texture == null)
            {
                Console.WriteLine("Texture file at " + path +
                    " was not found... Trying to add...");
                LoadTexture(path);
                Assets.TryGetValue(path, out texture);
            }

            return texture;
        }

        private void RecursiveLoad(string p)
        {
            string[] paths = Directory.GetFiles(p);

            foreach (string s in paths)
            {
                if (s.Contains(".xnb"))
                {
                    if (!s.Contains("Font"))
                    {
                        string path = s.Substring(0, s.IndexOf(".xnb"));
                        path = path.Substring(path.IndexOf("Content/") + 8);
                        LoadTexture(path);
                    }
                }
            }

            string[] dPaths = Directory.GetDirectories(p);
            if (Directory.GetDirectories(p).Length > 0)
            {
                foreach (string s in dPaths)
                    RecursiveLoad(s);
            }
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
