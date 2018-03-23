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
    /// A component of the assembly line.
    /// </summary>
    public class Component
    {
        /// <summary>
        /// The texture of the component.
        /// </summary>
        public Texture2D Texture
        {
            get;
            set;
        }

        /// <summary>
        /// The position of the component.
        /// </summary>
        public Vector2 Position
        {
            get;
            set;
        }

        /// <summary>
        /// The size dimensions of the component.
        /// </summary>
        public Point Dimensions
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public float Rotation
        {
            get;
            set;
        }

        /// <summary>
        /// Updates the component.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the component to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }

    /// <summary>
    /// A direction components face and do work.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// East 0° or 360°
        /// </summary>
        EAST,

        /// <summary>
        /// [N45°E] 45°
        /// </summary>
        NORTHEAST,

        /// <summary>
        /// North 90°
        /// </summary>
        NORTH,

        /// <summary>
        /// [N45°W] 135°
        /// </summary>
        NORTHWEST,

        /// <summary>
        /// West 180°
        /// </summary>
        WEST,

        /// <summary>
        /// [W45°S] 225°
        /// </summary>
        SOUTHWEST,

        /// <summary>
        /// South 270°
        /// </summary>
        SOUTH,

        /// <summary>
        /// [S45°E] 315°
        /// </summary>
        SOUTHEAST,
    }
}
