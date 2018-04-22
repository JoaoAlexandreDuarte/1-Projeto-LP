using System;

namespace Simplexity_Game {
    /// <summary>
    /// Class that will check if there's a win condition on the board
    /// </summary>
    class Checker {

        /// <summary>
        /// Initializes a new instance of the <see cref="Checker{T}"/> class.
        /// </summary>
        public Checker() {

        }

        /// <summary>
        /// Checks all the Win Conditions by order, Shape has priority over
        /// color
        /// </summary>
        public Object CheckWin(Board board, Player player1, Player player2) {
            // General Object that will receive the winning Shape or the 
            // winning Color
            Object winCondition = null;
            // Empty player that will be returned
            Object wonPlayer = null;

            // Searches horizontally and vertically for 4 equal shapes
            winCondition = CheckLinear(board, "Shape");
            // Searches diagonally (both ways) for 4 equal shapes
            if (winCondition == null) {
                winCondition = CheckDiagonal(board, "Shape");
            }
            // Searches horizontally and vertically for 4 equal colors
            if (winCondition == null) {
                winCondition = CheckLinear(board, "Color");
            }
            // Searches diagonally (both ways) for 4 equal colors
            if (winCondition == null) {
                winCondition = CheckDiagonal(board, "Color");
            }

            // If there's any kind of Win Condition it will return the
            // corresponding one, there's many if's in order to promote a 
            // good practice of only having 1 return 
            if (winCondition != null) {
                // If there's 4 cilinders then player one wins
                if ((Shape)winCondition == Shape.Cilinder) {
                    wonPlayer = PlayerNumber.One;
                    // If there's 4 cubes then player two wins
                } else if ((Shape)winCondition == Shape.Cube) {
                    wonPlayer = PlayerNumber.Two;
                    // If there's 4 white pieces then player one wins
                } else if ((Color)winCondition == Color.White) {
                    wonPlayer = PlayerNumber.One;
                    // If there's 4 red pieces then player two wins
                } else if ((Color)winCondition == Color.Red) {
                    wonPlayer = PlayerNumber.Two;
                    // If there's no pieces left the game ends in a draw
                } else if (ChecksDraw(player1, player2) == true) {
                    wonPlayer = 0;
                } else {
                    // If the code reaches here there's something wrong
                    wonPlayer = -1;
                }
            }

            return wonPlayer;
        }

        /// <summary>
        /// Checks if it's a draw by checking if there are no pieces left for
        /// both players
        /// </summary>
        private bool ChecksDraw(Player player1, Player player2) {
            // Initializes at null
            bool isDraw = false;

            // Checks if the players still have pieces
            if ((player1.TotalPieces == 0) && (player2.TotalPieces == 0)) {
                isDraw = true;
            }
            return isDraw;
        }

        /// <summary>
        /// Checks linearly, both horizontally and vertically, 
        /// receives the query that can be "Shape" or "Color" in order to know
        /// what it should search for 
        /// </summary>
        private Object CheckLinear(Board board, string query) {
            // Initializes the win condition at null
            Object winCondition = null;
            // Checks while the loop repeats itself
            bool isLooping = true;
            // Counts how many times the loop repeats 
            int cont = 0;
            // Creates four temporary variables according to the way
            Piece space1, space2, space3, space4;

            // If it's 0 it searches Horizontally, if it's 1 it searches
            // Vertically
            for (int i = 0; i < 2; i++) {
                // Loops through the board
                for (int row = 0; row < board.X; row++) {
                    for (int column = 0; column < board.Y - 3; column++) {
                        // Checks if it's horizontal
                        if (i == 0) {
                            space1 = board.BoardArray[row, column];
                            space2 = board.BoardArray[row, column + 1];
                            space3 = board.BoardArray[row, column + 2];
                            space4 = board.BoardArray[row, column + 3];
                            // Checks if it's vertical
                        } else {
                            space1 = board.BoardArray[column, row];
                            space2 = board.BoardArray[column + 1, row];
                            space3 = board.BoardArray[column + 2, row];
                            space4 = board.BoardArray[column + 3, row];
                        }

                        // If the spaces are empty it does nothing
                        if ((space1 == null) || (space2 == null) ||
                            (space3 == null) || (space4 == null)) {
                            // Verifies if they have something
                        } else {

                            // The searching method verifies for shapes
                            if (query == "Shape") {

                                // If there are 4 equal shapes in order it sets 
                                // the win condition as the shape and stops
                                // looping
                                if ((space1.Shape == space2.Shape) &&
                                    (space1.Shape == space3.Shape) &&
                                    (space1.Shape == space4.Shape)) {

                                    winCondition = space1.Shape;
                                    isLooping = false;
                                }
                                // The searching method verifies for color
                            } else {

                                // If there are 4 equal colors in order it sets 
                                // the win condition as the color and stops
                                // looping
                                if ((space1.Color == space2.Color) &&
                                    (space1.Color == space3.Color) &&
                                    (space1.Color == space4.Color)) {

                                    winCondition = space1.Color;
                                    isLooping = false;
                                }
                            }
                        }
                    }
                    // Breaks the loop
                    if (!isLooping) break;
                }
                // Breaks the loop
                if (!isLooping) break;
            }
            return winCondition;
        }

        /// <summary>
        /// Checks diagonally, both right-up and right-down, receives the query
        /// that can be "Shape" or "Color" in order to know what it should
        /// search for 
        /// </summary>
        private Object CheckDiagonal(Board board, string query) {
            // Initializes the win condition at null
            Object winCondition = null;
            // Checks while the loop repeats itself
            bool isLooping = true;
            // Default space that will compare to others
            Piece starter;

            // Loops through the array
            for (int column = 0; column < board.Y - 3; column++) {
                // Loops to the right and down ( it increments 1 in both the
                // column and the row )
                for (int row = 0; row < board.X - 4; row++) {

                    // Starter space
                    starter = board.BoardArray[row, column];

                    // If the spaces are empty it does nothing
                    if ((starter == null) ||
                        (board.BoardArray[row + 1, column + 1] == null) ||
                        (board.BoardArray[row + 2, column + 2] == null) ||
                        (board.BoardArray[row + 3, column + 3] == null)) {

                        // If the spaces are not empty it will try to check for
                        // 4 equal Shapes or Colors
                    } else {
                        // Searching method verifies for shapes
                        if (query == "Shape") {

                            // If there are 4 equal shapes in order it sets the
                            // win condition as the shape and stops looping
                            if ((starter.Shape ==
                                board.BoardArray[row + 1, column + 1].Shape) &&
                                (starter.Shape ==
                                board.BoardArray[row + 2, column + 2].Shape) &&
                                (starter.Shape ==
                                board.BoardArray[row + 3, column + 3].Shape)) {

                                winCondition = starter.Shape;
                                isLooping = false;
                            }

                            // Searching method verifies for colors
                        } else {

                            // If there are 4 equal shapes in order it sets the
                            // win condition as the shape and stops looping
                            if ((starter.Color ==
                                board.BoardArray[row + 1, column + 1].Color) &&
                                (starter.Color ==
                                board.BoardArray[row + 2, column + 2].Color) &&
                                (starter.Color ==
                                board.BoardArray[row + 3, column + 3].Color)) {

                                winCondition = starter.Color;
                                isLooping = false;
                            }
                        }
                    }
                    // Breaks the loop
                    if (!isLooping) break;
                }

                // Breaks the loop
                if (!isLooping) break;

                // Loops to the right and up ( it decrements 1 in the column 
                // and the decremetns 1 in the row )
                for (int row = (board.X - board.X + 3); row < board.X - 1;
                    row++) {

                    // Starter space
                    starter = board.BoardArray[row, column];

                    // If the spaces are empty it does nothing
                    if ((starter == null) ||
                        (board.BoardArray[row - 1, column + 1] == null) ||
                        (board.BoardArray[row - 2, column + 2] == null) ||
                        (board.BoardArray[row - 3, column + 3] == null)) {

                    } else {
                        // Searching method verifies for shapes
                        if (query == "Shape") {

                            // If there are 4 equal colors in order it sets the
                            // win condition as the color and stops looping
                            if ((starter.Shape ==
                                board.BoardArray[row - 1, column + 1].Shape) &&
                                (starter.Shape ==
                                board.BoardArray[row - 2, column + 2].Shape) &&
                                (starter.Shape ==
                                board.BoardArray[row - 3, column + 3].Shape)) {

                                winCondition = starter.Shape;
                                isLooping = false;
                            }

                            //Searching method verifies for colors
                        } else {

                            // If there are 4 equal colors in order it sets the
                            // win condition as the color and stops looping
                            if ((starter.Color ==
                                board.BoardArray[row - 1, column + 1].Color) &&
                                (starter.Color ==
                                board.BoardArray[row - 2, column + 2].Color) &&
                                (starter.Color ==
                                board.BoardArray[row - 3, column + 3].Color)) {

                                winCondition = starter.Color;
                                isLooping = false;
                            }
                        }
                    }
                    // Breaks the loop
                    if (!isLooping) break;
                }
            }

            return winCondition;
        }
    }
}
