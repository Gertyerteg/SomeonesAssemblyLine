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
using SAL.Components;

namespace SAL.GameStates
{
    /// <summary>
    /// The main game state for the game instance.
    /// </summary>
    public class MainState : GameState
    {
        private List<Component> components;
        private Selector selector;

        private Camera camera;

        /// <summary>
        /// Creates and initializes a new instance of <c>MainState</c>
        /// </summary>
        public MainState(SomeonesAssemblyLine inst) 
            : base(inst)
        {
            camera = new Camera(inst.GraphicsDevice.Viewport);
            components = new List<Component>();
        }

        /// <summary>
        /// Loads the assets for the <c>MainState</c>.
        /// </summary>
        public override void Load()
        {
            base.Load();

            Texture2D texture = GameManager.GetInstance().GetTexture("Conveyer_Belt");

            selector = new Selector();
            selector.LoadContent(Content);

            ConveyorBelt b = new ConveyorBelt
            {
                Texture = texture,
                Direction = Direction.NORTH,
                Dimensions = new Point(64, 64),
                Position = new Vector2(0, 64)
            };
            ConveyorBelt a = new ConveyorBelt
            {
                Texture = texture,
                Direction = Direction.NORTH,
                Dimensions = new Point(64, 64),
                Position = new Vector2(0, 0)
            };

            ConveyorBelt c = new ConveyorBelt
            {
                Texture = texture,
                Direction = Direction.NORTH,
                Dimensions = new Point(64, 64),
                Position = new Vector2(0, 128)
            };

            components.Add(a);
            components.Add(b);
            components.Add(c);
        }

        /// <summary>
        /// Updates the main state of the game.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Component c in components)
                c.Update(gameTime);

            selector.Update(gameTime, camera);
        }

        /// <summary>
        /// Draws the main game state.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="graphics"></param>
        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            base.Draw(spriteBatch, graphics);

            spriteBatch.Begin();

            foreach (Component c in components)
                c.Draw(spriteBatch);

            selector.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
