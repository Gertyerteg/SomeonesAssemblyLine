using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL.Components
{
    /// <summary>
    /// A resource that is placed into the assembly line to be either made into
    /// a refined product or sold as raw.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// The texture of the <c>Resource</c>.
        /// </summary>
        public Texture2D Texture
        {
            get;
            set;
        }

        /// <summary>
        /// The position of the <c>Resource</c>.
        /// </summary>
        public Vector2 Position
        {
            get;
            set;
        }

        /// <summary>
        /// The dimensions of the <c>Resource</c>.
        /// </summary>
        public Point Dimensions
        {
            get;
            set;
        }

        /// <summary>
        /// The color that is drawn.
        /// </summary>
        public Color Color
        {
            get;
            set;
        }
        
        /// <summary>
        /// Creates a new instance of <c>Resource</c>.
        /// </summary>
        public Resource()
        {
            Color = Color.White;
        }

        /// <summary>
        /// Updates the <c>Resource</c>.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the <c>Resource</c> to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position.ToPoint(), Dimensions), Color);
        }
    }
}
