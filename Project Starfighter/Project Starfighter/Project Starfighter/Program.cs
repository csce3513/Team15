using System;

namespace Project_Starfighter
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Starfighter game = new Starfighter())
            {
                game.Run();
            }
        }
    }
#endif
}

