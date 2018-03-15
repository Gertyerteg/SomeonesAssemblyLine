/**
 * Someone's Assembly Line
 * 
 * Design your own factory! Manufactor different components through an assembly line
 * to build up your wealth.
 */
using System;

namespace SAL
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new SomeonesAssemblyLine())
                game.Run();
        }
    }
#endif
}
