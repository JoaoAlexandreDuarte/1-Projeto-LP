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
        public Object CheckWin(Board board) {
            // General Object that will receive the winning Shape or the 
            // winning Color
            Object winCondition = null;
            // Empty player that will be returned
            Object wonPlayer = null;

            // Checks the Win Conditions by Shape
            winCondition = CheckLinear(board, "Shape", "Horizontal");
            if (winCondition == null) {
                winCondition = CheckLinear(board, "Shape", "Vertical");
            } else if (winCondition == null) {
                winCondition = CheckLinear(board, "Color", "Horizontal");
            } else if (winCondition == null) {
                winCondition = CheckLinear(board, "Color", "Vertical");
            }


            // If there's any kind of Win Condition it will return the
            // corresponding one, there's many if's in order to promote a 
            // good practice of only having 1 return 
            if (winCondition != null) {
                if ((Shape)winCondition == Shape.Cilinder) {
                    wonPlayer = PlayerNumber.One;
                } else if ((Shape)winCondition == Shape.Cube) {
                    wonPlayer = PlayerNumber.Two;
                } else if ((Color)winCondition == Color.White) {
                    wonPlayer = PlayerNumber.One;
                } else if ((Color)winCondition == Color.Red) {
                    wonPlayer = PlayerNumber.Two;
                } else {
                    // If the code reaches here there's something wrong
                    wonPlayer = -1;
                }
            }

            return wonPlayer;
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
            for (int i = 0; i < board.X; i++) {
                for (int j = 0; j < board.Y - 1; j++) {
                    // Checks if it's horizontal
                    if (way == "Horizontal") {
                        space1 = board.BoardArray[i, j];
                        space2 = board.BoardArray[i, j + 1];
                    // Checks if it's vertical
                    } else {
                        space1 = board.BoardArray[j, i];
                        space2 = board.BoardArray[j + 1, i];
                    }

                    // Verificates if the spaces are null
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
                            // If neither the conditions are true it will reset
                            // the counter
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
                                // If neither the conditions are true it will reset
                                // the counter
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
    }
}
