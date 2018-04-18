using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity_Game {
    class Program {
        static void Main(string[] args) {
            Interface board = new Interface();

            board.ShowBoard();

            Console.ReadKey();
        }
    }
}
