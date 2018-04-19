using System;

namespace Simplexity_Game {
    /// <summary>
    /// Class that renders the interface to the user
    /// </summary>
    public class Interface {
        // Variables that keep the Cube and Cilinder shapes
        private string square = "\u25a0  ";
        private string circle = "O  ";

        /// <summary>
        /// Constructs the interface so that it's possible to call their
        /// methods
        /// </summary>
        public Interface() {

        }

        public void ShowCurrentPieces(Player player) {
            Console.WriteLine("\nPlayer " + player.Number +
                  " has a total of " + player.TotalPieces +
                  " pieces to play right now (" + player.CubesNumber() +
                  " cubes and " + player.CilindersNumber() + " cilinders");
        }

        public void ShowBoard(Piece[,] board) {
            for (int i = 0; i < 7; i++) {
                Console.Write(" ");

                for (int j = 0; j < 7; j++) {

                    if (board[i, j] == null) {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("|  ");
                        Console.ResetColor();
                    } else if (board[i, j].Color == Color.White) {
                        if (board[i, j].Shape == Shape.Cube) {
                            Console.Write(square);
                        } else if (board[i, j].Shape == Shape.Cilinder) {
                            Console.Write(circle);
                        } else {
                            Console.Write("? ");
                        }
                    } else if (board[i, j].Color == Color.Red) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (board[i, j].Shape == Shape.Cube) {
                            Console.Write(square);
                        } else if (board[i, j].Shape == Shape.Cilinder) {
                            Console.Write(circle);
                        } else {
                            Console.Write("?  ");
                        }
                        Console.ResetColor();
                    } else {
                        Console.Write("??");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ------------------- \n 1  2  3  4  5  6  7");
            Console.ResetColor();
        }
    }
}
