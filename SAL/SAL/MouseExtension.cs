using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL
{
    /// <summary>
    /// Extension methods for the Monogame <c>Mouse</c> class.
    /// </summary>
    public static class MouseExtension
    {
        /// <summary>
        /// Calculates and returns the position relative to the camera.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static Vector2 RelativePosition(this MouseState state, Camera camera)
        {
            return Vector2.Transform(state.Position.ToVector2(), Matrix.Invert(camera.GetMatrixView()));
        }
    }
}
