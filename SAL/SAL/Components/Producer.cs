using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SAL.GameStates;

namespace SAL.Components
{
    /// <summary>
    /// A producer for providing raw materials and resources to be either sold or turned into
    /// more developed resources.
    /// </summary>
    public class Producer : Component
    {
        private float produceTimer;

        /// <summary>
        /// Direction production is flowing in.
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// The status of the <c>Producer</c>'s production.
        /// </summary>
        public bool IsProducing
        {
            get;
            set;
        }

        /// <summary>
        /// The base production time to produce resources.
        /// </summary>
        public readonly float BASE_PRODUCTION_TIME;
        private MainState state;

        /// <summary>
        /// Creates and initializes a new instance of <c>Producer</c>.
        /// </summary>
        public Producer(float time, MainState state)
            : base()
        {
            this.state = state;
            BASE_PRODUCTION_TIME = time;
            produceTimer = 0f;
            IsProducing = false;
            Direction = Direction.SOUTH;
        }

        /// <summary>
        /// Updates the <c>Producer</c> and logic.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsProducing)
            {
                produceTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (produceTimer >= BASE_PRODUCTION_TIME)
                {
                    produceTimer = 0f;

                    Produce();
                }
            }
            Rotation = MathHelper.PiOver4 * (int)Direction;

        }

        /// <summary>
        /// Produces a resource into the assembly line.
        /// </summary>
        public void Produce()
        {
            Resource r = new Resource
            {
                Texture = GameManager.GetInstance().GetTexture("Blank"),
                Color = Color.Gold,
                Dimensions = new Point(10, 10),
                Position = Position,
            };
            state.Resources.Add(r);
        }

        /// <summary>
        /// Draws the producer to the screen.
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
