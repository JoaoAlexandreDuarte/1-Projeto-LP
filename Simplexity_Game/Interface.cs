using System;

namespace Simplexity_Game {
    /// <summary>
    /// Class that renders the interface to the user such as the board and the
    /// respective messages or errors
    /// </summary>
    public class Interface {
        // Variables that keep the Cube and Cilinder shapes so that's easy to
        // change if needed
        private string square = "\u25a0  ";
        private string circle = "O  ";

        /// <summary>
        /// Initializes a new instance of the <see cref="Interface{T}"/> class.
        /// </summary>
        public Interface() {

        }

        /// <summary>
        /// Renders the information available to the player
        /// </summary>
        public void ShowInfo(Player player) {
            Console.WriteLine("Player " + (int)player.Number +
                  " has a total of " + player.TotalPieces +
                  " pieces to play right now (" + player.CubesNumber +
                  " cubes and " + player.CilindersNumber + " cilinders)");
        }

        /// <summary>
        /// Renders the question about the column in which the player wants to
        /// play
        /// </summary>
        public void AskColumn() {
            Console.WriteLine("\nAt which column do you want to place your" +
                    " piece?");
        }

        /// <summary>
        /// Renders the question about which piece the player wants to play
        /// </summary>
        public void AskPiece() {
            Console.WriteLine("Which piece do you want to play? (1/Cube or " +
                "2/Cilinder)");
        }

        /// <summary>
        /// Renders the error for when the player inputs a wrong column number
        /// </summary>
        public void ErrorColumn() {
            Console.WriteLine("\nNot a recognizeable column number! (Valid " +
                "inputs are 1 up to 7)");
            Console.ReadLine();
        }

        /// <summary>
        /// Renders the error for when the player inputs a wrong piece
        /// </summary>
        public void ErrorPiece() {
            Console.WriteLine("\nNot a recognizeable piece! (Valid inputs" + 
                "1/Cube/cube OR 2/Cilinder/cilinder)");
            Console.ReadLine();
        }

        /// <summary>
        /// Renders the error for when the player places a piece in a filled
        /// row
        /// </summary>
        public void ErrorPlace() {
            Console.WriteLine("\nThe row is either full or you placed a piece" +
                " you no longer have! Check another one");
            Console.ReadLine();
        }

        /// <summary>
        /// Indicates the current turn
        /// </summary>
        public void CurrentTurn(int turn) {
            Console.WriteLine("\nCurrent turn: " + (turn + 1));
        }

        /// <summary>
        /// Displays the final message
        /// </summary>
        /// <param name="result"></param>
        public void FinalMessage(Object result) {
            // Message for when the player one wins
            if ((PlayerNumber)result == PlayerNumber.One) {
                Console.WriteLine("\nPlayer 1 has won!");
            // Message for when the player two wins
            } else if ((PlayerNumber)result == PlayerNumber.Two) {
                Console.WriteLine("\nPlayer 2 has won!");
            // Message for when it's a draw
            } else if ((int)result == 0) {
                Console.WriteLine("\nThe game has ended in a draw!");
            // Error message
            } else {
                Console.WriteLine("\nSomething went wrong!");
            }
        }

        /// <summary>
        /// Renders the board
        /// </summary>
        public void ShowBoard(Piece[,] board) {
            // Starts at the end so that the pieces "fall" down instead of 
            // starting at the top, changing the point of view
            for (int i = 6; i >= 0; i--) {
                Console.Write(" ");

                for (int j = 0; j < 7; j++) {

                    // Checks which piece is placed on the current board 
                    // position and displays it

                    // If there's no piece
                    if (board[i, j] == null) {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("|  ");
                        Console.ResetColor();

                        // If there's a White Cilinder
                    } else if ((board[i, j].Color == Color.White) &&
                        (board[i, j].Shape == Shape.Cilinder)) {
                        Console.Write(circle);

                        // If there's a  White Cube
                    } else if ((board[i, j].Color == Color.White) &&
                        (board[i, j].Shape == Shape.Cube)) {
                        Console.Write(square);

                        // If it's a Red Cube
                    } else if ((board[i, j].Color == Color.Red) &&
                        (board[i, j].Shape == Shape.Cube)) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(square);
                        Console.ResetColor();

                        // If it's a Red Cilinder
                    } else if ((board[i, j].Color == Color.Red) &&
                        (board[i, j].Shape == Shape.Cilinder)) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(circle);
                        Console.ResetColor();
                    } else {

                        // If something goes wrong
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("? ");
                        Console.ResetColor();
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
