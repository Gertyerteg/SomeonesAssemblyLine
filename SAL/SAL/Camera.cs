#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

//-----------------------------------------------------------------
//	Author:				Spencer Chang
//	Date:				May 16, 2017
//	Notes:				
//-----------------------------------------------------------------

namespace SAL
{
    ///	<summary>
    ///	Camera that handles transitions inside of the matrix.
    ///	</summary>
    public class Camera
    {
        #region Fields
        public const float MAX_ZOOM = 0.40f;
        private Vector2 center;
        #endregion

        #region Properties
        /// <summary>
        /// The center x position of the camera.
        /// </summary>
        public float X
        {
            get { return center.X; }
            set { center.X = value; }
        }

        /// <summary>
        /// The center y position of the camera.
        /// </summary>
        public float Y
        {
            get { return center.Y; }
            set { center.Y = value; }
        }

        /// <summary>
        /// The rotation of the camera.
        /// </summary>
        public float Rotation
        {
            get;
            set;
        }

        /// <summary>
        /// The zoom of the camera.
        /// </summary>
        public float Zoom
        {
            set
            {
                if (value >= MAX_ZOOM)
                    zoom = value;
            }
            get { return zoom; }
        }

        private float zoom;

        /// <summary>
        /// Point of the camera.
        /// </summary>
        public Point Point
        {
            get { return Position.ToPoint(); }
        }

        /// <summary>
        /// Position of the camera.
        /// </summary>
        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
        }

        public Viewport viewport;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates and initializes a new instance of a <c>Camera</c> object.
        /// </summary>
        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
            center = Vector2.Zero;
            zoom = 1f;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Looks at a specified point.
        /// </summary>
        /// <param name="point"></param>
        public void LookAt(Vector2 point)
        {
            center = new Vector2(point.X, point.Y);
        }

        /// <summary>
        /// Zooms in by a factor.
        /// </summary>
        /// <param name="factor"></param>
        public void ChangeZoom(float factor)
        {
            Zoom += factor;
        }

        /// <summary>
        /// Returns the matrix for 2D transformations.
        /// </summary>
        /// <returns></returns>
        public Matrix GetMatrixView()
        {
            //return Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
            return Matrix.CreateTranslation(new Vector3 (-center.X, -center.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, Zoom) *
                Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));
        }
        #endregion
    }
}
