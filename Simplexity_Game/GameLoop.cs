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
            // Creates the 2 players
            Player player1 = new Player(PlayerNumber.One);
            Player player2 = new Player(PlayerNumber.Two);
            // Creates a variable that will keep the current player
            Player currentPlayer;
            // Starts at turn 0
            int turn = 0;

            do {

                Console.WriteLine();
                // Shows the Board state
                visualization.ShowBoard(board.BoardArray);

                //
                currentPlayer = (turn % 2) == 0 ? player1 : player2;

                visualization.ShowCurrentPieces(currentPlayer);

                Console.WriteLine();

                Console.ReadLine();

                turn++;
            } while (turn < 50);

        }
    }
}
