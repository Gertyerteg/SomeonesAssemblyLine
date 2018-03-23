using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SAL.Components
{
    /// <summary>
    /// A conveyor belt component for carrying different items.
    /// </summary>
    public class ConveyorBelt : Component
    {
        /// <summary>
        /// The direction the conveyor belt moves items in.
        /// </summary>
        public Direction Direction
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new instance of the <c>ConveyorBelt</c>.
        /// </summary>
        public ConveyorBelt()
        {
            Direction = Direction.EAST;
        }

        /// <summary>
        /// Updates the <c>ConveyorBelt</c>.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Rotation = MathHelper.PiOver4 * (int)Direction;
        }

        /// <summary>
        /// Draws the conveyor belt with the correct orientation.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(Texture, new Rectangle((Position + Dimensions.ToVector2() / 2)
                .ToPoint(), Dimensions), null, Color.White, Rotation, new Vector2(Texture.Width 
                / 2, Texture.Height / 2), SpriteEffects.None, 0f);
        }
    }
}
