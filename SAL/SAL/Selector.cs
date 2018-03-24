/**
 * Spencer Chang
 * March 22, 2018
 * 
 * A component for selecting the place of tiles.
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL
{
    /// <summary>
    /// The Selector for selecting placements on a tilemap.
    /// </summary>
    public class Selector
    {
        private Texture2D[] textures;
        private Rectangle[] drawRectangles;
        private Vector2 position;

        /// <summary>
        /// Creates a new instance of a <c>Selector</c>.
        /// </summary>
        public Selector()
        {
            position = Vector2.Zero;
        }

        /// <summary>
        /// Loads the content of the <c>Selector</c>.
        /// </summary>
        /// <param name="Content"></param>
        public void LoadContent(ContentManager Content)
        {
            // loads the textures of the selector
            textures = new Texture2D[4];
            textures[0] = Content.Load<Texture2D>("SelectorTL");
            textures[1] = Content.Load<Texture2D>("SelectorTR");
            textures[2] = Content.Load<Texture2D>("SelectorBL");
            textures[3] = Content.Load<Texture2D>("SelectorBR");

            // initializes the draw rectangles
            drawRectangles = new Rectangle[4];
            drawRectangles[0] = new Rectangle(0, 0, 64, 64);
            drawRectangles[1] = new Rectangle(0, 0, 64, 64);
            drawRectangles[2] = new Rectangle(0, 0, 64, 64);
            drawRectangles[3] = new Rectangle(0, 0, 64, 64);
        }

        /// <summary>
        /// Updates the <c>Selector</c> logic.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="camera"></param>
        public void Update(GameTime gameTime, Camera camera)
        {
            //if (Mouse.GetState().LeftButton.Equals(ButtonState.Pressed))
            //{
            //    // special case for selector
            //}
            //else
            //{
            for (int i = 0; i < drawRectangles.Length; i++)
                drawRectangles[i] = new Rectangle((int)(Mouse.GetState().RelativePosition(camera).X / 64) * 64,
                    (int)(Mouse.GetState().RelativePosition(camera).Y / 64) * 64, 64, 64);
            //}
        }

        /// <summary>
        /// Draws the selector to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < textures.Length; i++)
                spriteBatch.Draw(textures[i], drawRectangles[i], Color.White);
        }
    }
}
