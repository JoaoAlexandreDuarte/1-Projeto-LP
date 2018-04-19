using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity_Game {
    public class Program {
        /// <summary>
        /// Main method that initializes the Game
        /// </summary>
        static void Main(string[] args) {
            // Creates an instance of GameLoop to start the game
            GameLoop gameLoop = new GameLoop();
            gameLoop.Update();
        }
    }
}
