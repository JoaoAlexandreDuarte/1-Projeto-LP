using System;

namespace Simplexity_Game {

    /// <summary>
    /// Class that wil serve as the Gameloop to run the game cicles
    /// </summary>
    public class GameLoop {

        /// <summary>
        /// Constructor for the GameLoop
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

            do {
                Console.Clear();
                Console.WriteLine();
                // Shows the Board state
                visualization.ShowBoard(board.BoardArray);

                //
                currentPlayer = (turn % 2) == 0 ? player1 : player2;


                Console.WriteLine("\nCurrent turn: " + (turn + 1));
                visualization.ShowInfo(currentPlayer);

                visualization.AskColumn();

                // TryParse tries to convert to int32, used this way so that
                // clicking enter by mistake (empty string) doesn't crash the
                // program.
                Int32.TryParse(Console.ReadLine(), out column);

                if ((column >= 1) && (column <= 7)) {
                    visualization.AskPiece();

                    shape = Console.ReadLine();

                    if ((shape == "1") || (shape == "cube") ||
                        (shape == "Cube")) {
                        board.PlacePiece(currentPlayer.PlayCube(), column - 1);
                    } else if ((shape == "2") || (shape == "cilinder") ||
                        (shape == "Cilinder")) {
                        board.PlacePiece(currentPlayer.PlayCilinder(),
                            column - 1);
                    } else {
                        visualization.ErrorPiece();
                        turn--;
                    }
                } else {
                    visualization.ErrorColumn();
                    turn--;
                }


                turn++;
            } while (turn < 50);

        }
    }
}
