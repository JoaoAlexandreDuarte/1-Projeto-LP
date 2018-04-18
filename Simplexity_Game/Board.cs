using System;

namespace Simplexity_Game {
    /// <summary>
    /// Class that creates the board and checks for the win condition
    /// </summary>
    public class Board {
        // Array Piece that represents the board
        public Piece[,] Board { get; }
        
        /// <summary>
        /// Constructs the board
        /// </summary>
        public Board() {
            //Initializes the board
            Board = new Piece[7,7]; //hi friend :)
        }

        public void GetPiece(Piece piece, int column) {

        }

    }
}
