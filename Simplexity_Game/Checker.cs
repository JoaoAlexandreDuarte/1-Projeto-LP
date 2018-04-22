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

            // Searches horizontally for 4 equal shapes
            winCondition = CheckLinear(board, "Shape", "Horizontal");
            // Searches vertically for 4 equal shapes
            if (winCondition == null) {
                winCondition = CheckLinear(board, "Shape", "Vertical");
            }
            // Searches diagonally for 4 equal shapes
            if (winCondition == null) {
                winCondition = CheckDiagonal(board, "Shape");
            }
            // Searches horizontally for 4 equal colors
            if (winCondition == null) {
                winCondition = CheckLinear(board, "Color", "Horizontal");
            }
            // Searches vertically for 4 equal colors
            if (winCondition == null) {
                winCondition = CheckLinear(board, "Color", "Vertical");
            }
            // Searches diagonally for 4 equal colors
            if (winCondition == null) {
                winCondition = CheckDiagonal(board, "~Color");
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
        /// Checks if it's a draw
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
        /// Checks linearly, both horizontally and vertically according to the
        /// way input, receives the query that can be "Shape" or "Color" in
        /// order to know what it should search for 
        /// </summary>
        private Object CheckLinear(Board board, string query, string way) {
            // Initializes the win condition at null
            Object winCondition = null;
            // Checks while the loop repeats itself
            bool isLooping = true;
            // Counts how many times the loop repeats 
            int cont = 0;
            // Creates two temporary variables according to the query
            Object temp1 = null, temp2 = null;
            // Creates two temporary variables according to the way
            Piece space1, space2;

            // Loops through the board
            for (int row = 0; row < board.X; row++) {
                for (int column = 0; column < board.Y - 1; column++) {
                    // Checks if it's horizontal
                    if (way == "Horizontal") {
                        space1 = board.BoardArray[row, column];
                        space2 = board.BoardArray[row, column + 1];
                        // Checks if it's vertical
                    } else {
                        space1 = board.BoardArray[column, row];
                        space2 = board.BoardArray[column + 1, row];
                    }

                    // Verificates if the spaces are empty
                    if ((space1 == null) || (space2 == null)) {
                        cont = 0;
                        // Verificates if they have something
                    } else {

                        // The searching method verifies for shapes
                        if (query == "Shape") {
                            temp1 = space1.Shape;
                            temp2 = space2.Shape;

                            // Compares the current variable to the next
                            if ((Shape)temp1 == (Shape)temp2) {
                                // Adds one to the counter
                                cont++;
                                // Checks if it has 4 pieces in a row and sends
                                // the information to the method that checks
                                // for the win condition
                                if (cont == 3) {
                                    // Returns the type of the piece
                                    winCondition = temp2;
                                    isLooping = false;
                                    break;
                                }
                                // If neither the conditions are true it will
                                // reset the counter
                            } else {
                                cont = 0;
                            }
                            // The searching method verifies for color
                        } else {
                            temp1 = space1.Color;
                            temp2 = space2.Color;

                            // Compares the current variable to the next
                            if ((Color)temp1 == (Color)temp2) {
                                // Adds one to the counter
                                cont++;
                                // Checks if it has 4 pieces in a row and sends
                                // the information to the method that checks
                                // for the win condition
                                if (cont == 3) {
                                    // Returns the type of the piece
                                    winCondition = temp2;
                                    isLooping = false;
                                    break;
                                }
                                // If neither the conditions are true it will
                                // reset the counter
                            } else {
                                cont = 0;
                            }
                        }
                    }
                }
                // Breaks the loop
                if (!isLooping) break;
            }
            return winCondition;
        }

        /// <summary>
        /// Searches 
        /// </summary>
        private Object CheckDiagonal(Board board, string query) {
            // Initializes the win condition at null
            Object winCondition = null;
            // Checks while the loop repeats itself
            bool isLooping = true;
            // Default piece that will compare to others
            Piece starter;

            // Loops through the array
            for (int column = 0; column < board.Y - 3; column++) {
                // Loops to the right and down
                for (int row = 0; row < board.X - 4; row++) {

                    starter = board.BoardArray[row, column];

                    // If the spaces are empty it does nothing
                    if ((starter == null) ||
                        (board.BoardArray[row + 1, column + 1] == null) ||
                        (board.BoardArray[row + 2, column + 2] == null) ||
                        (board.BoardArray[row + 3, column + 3] == null)) {

                    } else {
                        // Searching method verifies for shapes
                        if (query == "Shape") {

                            if ((starter.Shape ==
                                board.BoardArray[row + 1, column + 1].Shape) &&
                                (starter.Shape ==
                                board.BoardArray[row + 2, column + 2].Shape) &&
                                (starter.Shape ==
                                board.BoardArray[row + 3, column + 3].Shape)) {

                                winCondition = starter.Shape;
                                isLooping = false;
                            }

                            //Searching method verifies for colors
                        } else {

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
                    if (!isLooping) break;
                }

                if (!isLooping) break;
                // Loops to the right and up
                for (int row = (board.X - board.X + 3); row < board.X - 1;
                    row++) {

                    starter = board.BoardArray[row, column];

                    // If the spaces are empty it does nothing
                    if ((starter == null) ||
                        (board.BoardArray[row - 1, column + 1] == null) ||
                        (board.BoardArray[row - 2, column + 2] == null) ||
                        (board.BoardArray[row - 3, column + 3] == null)) {

                    } else {
                        // Searching method verifies for shapes
                        if (query == "Shape") {

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
                    if (!isLooping) break;
                }
            }

            return winCondition;
        }
    }
}
