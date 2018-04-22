using System;

namespace Simplexity_Game {

    /// <summary>
    /// Class that will serve as the Gameloop to run the game cycles and 
    /// communicate between the needed classes
    /// </summary>
    public class GameLoop {

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLoop{T}"/> class.
        /// </summary>
        public GameLoop() {

        }

        /// <summary>
        /// Method that will update the game as it progresses
        /// </summary>
        public void Update() {
            // Creates the board
            Board board = new Board();
            // Creates the interface
            Interface visualization = new Interface();
            // Creates the checker
            Checker checker = new Checker();
            // Creates the 2 players
            Player player1 = new Player(PlayerNumber.One);
            Player player2 = new Player(PlayerNumber.Two);
            // Creates a variable that will keep the current player
            Player currentPlayer;
            // Starts at turn 0
            int turn = 0;
            // Column input
            int column;
            // Piece input
            string shape;
            // Empty object that saves the player that won
            Object end = null;

            do {
                Console.Clear();
                Console.WriteLine();
                // Shows the Board state
                visualization.ShowBoard(board.BoardArray);

                // If the number of the turn is divisible by 2, then it's the
                // player 1's turn, if not, it's the other player's turn
                currentPlayer = (turn % 2) == 0 ? player1 : player2;

                // Indicates the current turn
                visualization.CurrentTurn(turn);
                // Information about the current player
                visualization.ShowInfo(currentPlayer);

                // Asks which column the player wants to play the piece
                visualization.AskColumn();

                // TryParse tries to convert to int32, used this way so that
                // clicking enter by mistake (empty string) doesn't crash the
                // program.
                Int32.TryParse(Console.ReadLine(), out column);

                // If it's a valid value(1-7), because it's what the player sees
                if ((column >= 1) && (column <= 7)) {
                    // Asks which piece to play
                    visualization.AskPiece();

                    shape = Console.ReadLine();

                    // Verifies if it's a valid input for cube
                    if ((shape == "1") || (shape == "cube") ||
                        (shape == "Cube")) {
                        // If the returned value of the method is false, shows
                        // the error message
                        if (!board.PlacePiece(currentPlayer.PlayCube(),
                            column - 1)) {
                            turn--;
                            visualization.ErrorPlace();
                        }
                    // Verifies if it's a valid input for cilinder
                    } else if ((shape == "2") || (shape == "cilinder") ||
                        (shape == "Cilinder")) {
                        // If the returned value of the method is false, shows
                        // the error message
                        if (!board.PlacePiece(currentPlayer.PlayCilinder(),
                            column - 1)) {
                            turn--;
                            visualization.ErrorPlace();
                        }
                    // If it's neither it'll display the error piece message
                    } else {
                        visualization.ErrorPiece();
                        turn--;
                    }
                // If it's neither it'll display the error column message
                } else {
                    visualization.ErrorColumn();
                    turn--;
                }

                // Verifies if the game has finished
                end = checker.CheckWin(board, player1, player2);

                turn++;
            // While there's no winner, the game will continue to repeat
            } while (end == null);

            Console.Clear();
            // Shows the board one last time so that the player can see
            visualization.ShowBoard(board.BoardArray);
            // Displays the end message
            visualization.FinalMessage(end);
            Console.ReadKey();
        }
    }
}
