/**
 * Spencer Chang
 * 15 March 2018
 * 
 * The main state of the game. This is where most of the game components will function: Draw
 * and Update.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SAL.Components;
#endregion

namespace SAL.GameStates
{
    /// <summary>
    /// The main game state for the game instance.
    /// </summary>
    public class MainState : GameState
    {
        /// <summary>
        /// The components of the assembly line.
        /// </summary>
        public List<Component> Components;

        /// <summary>
        /// The resources produced by the assembly line.
        /// </summary>
        public List<Resource> Resources;
        private Selector selector;

        /// <summary>
        /// User information holder for the player's progress.
        /// </summary>
        public GameProfile User;

        private Camera camera;
        private Vector2 initMouseClick;
        private SpriteFont font;
        private bool isMouseMovingCamera;
        private Texture2D blank, tileBorder;

        private int width, height;

        /// <summary>
        /// Creates and initializes a new instance of <c>MainState</c>
        /// </summary>
        public MainState(SomeonesAssemblyLine inst) 
            : base(inst)
        {
            camera = new Camera(inst.GraphicsDevice.Viewport);
            Components = new List<Component>();

            Resources = new List<Resource>();

            initMouseClick = Vector2.Zero;
            isMouseMovingCamera = false;

            width = 100;
            height = 80;

            User = new GameProfile
            {
                Money = 1200.0102f
            };

        }

        /// <summary>
        /// Loads the assets for the <c>MainState</c>.
        /// </summary>
        public override void Load()
        {
            base.Load();

            Texture2D texture = GameManager.GetInstance().GetTexture("Conveyer_Belt");
            Texture2D producer = GameManager.GetInstance().GetTexture("Producer");
            blank = GameManager.GetInstance().GetTexture("Blank");
            tileBorder = GameManager.GetInstance().GetTexture("TileBorder");
            font = Content.Load<SpriteFont>("Temp Font");

            selector = new Selector();
            selector.LoadContent(Content);

            ConveyorBelt b = new ConveyorBelt
            {
                Texture = texture,
                Direction = Direction.NORTH,
                Dimensions = new Point(64, 64),
                Position = new Vector2(0, 64)
            };
            Producer a = new Producer(1000f, this)
            {
                Texture = producer,
                IsProducing = true,
                Direction = Direction.SOUTH,
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

            Components.Add(a);
            Components.Add(b);
            Components.Add(c);
        }

        /// <summary>
        /// Updates the main state of the game.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Component c in Components)
                c.Update(gameTime);

            foreach (Resource r in Resources)
                r.Update(gameTime);

            // checks if the user is dragging mouse to move the camera
            if (InputManager.Instance.leftMouseButtonDown() && !isMouseMovingCamera)
            {
                initMouseClick = Mouse.GetState().Position.ToVector2();
                isMouseMovingCamera = true;
            }
            else if (!InputManager.Instance.leftMouseButtonDown())
            {
                isMouseMovingCamera = false;
            }

            float factor = 0.05f;
            if (InputManager.Instance.isScrollingUp())
                camera.ChangeZoom(-factor);
            else if (InputManager.Instance.isScrollingDown())
                camera.ChangeZoom(factor);

            if (isMouseMovingCamera)
            {
                camera.LookAt(camera.Position + (initMouseClick - Mouse.GetState().
                    Position.ToVector2()) / Math.Max(0.001f, camera.Zoom));
                initMouseClick = Mouse.GetState().Position.ToVector2();
            }

            // moves the camera with keys
            Vector2 cameraVel = Vector2.Zero;
            float camSpeed = 7f;
            if (InputManager.Instance.KeyDown(Keys.W))
                cameraVel.Y -= camSpeed;
            if (InputManager.Instance.KeyDown(Keys.S))
                cameraVel.Y += camSpeed;
            if (InputManager.Instance.KeyDown(Keys.A))
                cameraVel.X -= camSpeed;
            if (InputManager.Instance.KeyDown(Keys.D))
                cameraVel.X += camSpeed;

            selector.Update(gameTime, camera);
            camera.LookAt(camera.Position + cameraVel);
        }

        /// <summary>
        /// Draws the main game state.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="graphics"></param>
        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            base.Draw(spriteBatch, graphics);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                SamplerState.PointClamp, null, null, null, camera.GetMatrixView());

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Rectangle dRect = new Rectangle(x * 64, y * 64, 64, 64);
                    spriteBatch.Draw(blank, dRect, Color.White);
                    spriteBatch.Draw(tileBorder, dRect, Color.White);
                }
            }

            foreach (Component c in Components)
                c.Draw(spriteBatch);

            foreach (Resource r in Resources)
                r.Draw(spriteBatch);

            selector.Draw(spriteBatch);

            spriteBatch.End();

            spriteBatch.Begin();

            string money = String.Format("{0:0.##}", User.Money);
            if (User.Money >= 1000)
            {
                money = String.Format("{0:0.#} K", User.Money / 1000);
            }
            else if (User.Money >= 1000000)
            {
                money = String.Format("{0:0.#} M", User.Money / 1000000);
            }

            spriteBatch.DrawString(font, "$" + money, new Vector2(100, 100), Color.White);

            spriteBatch.End();
        }
    }
}
