using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL
{
    /// <summary>
    /// Holds information regarding the current user's save.
    /// </summary>
    public class GameProfile
    {
        /// <summary>
        /// The amount of currency the user possesses.
        /// </summary>
        public double Money
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new instance <c>GameProfile</c>.cs
        /// </summary>
        public GameProfile()
        {

        }
    }
}
