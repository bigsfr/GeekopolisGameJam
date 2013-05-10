using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameTutorial
{
    static class Program
    {
        private static ProjetOP game;

        [STAThread]
        static void Main()
        {
            game = new ProjetOP();
            game.Run();
        }
    }
}