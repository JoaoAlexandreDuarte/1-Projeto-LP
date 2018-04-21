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
            Object winCondition = null;
            bool isLooping = true;
            int cont = 0;
            Object temp1 = null, temp2 = null;
            Piece space1, space2;

            for (int i = 0; i < board.X; i++) {
                for (int j = 0; j < board.Y - 1; j++) {
                    if (way == "Horizontal") {
                        space1 = board.BoardArray[i, j];
                        space2 = board.BoardArray[i, j + 1];
                    } else {
                        space1 = board.BoardArray[j, i];
                        space2 = board.BoardArray[j + 1, i];
                    }

                    if ((space1 == null) || (space2 == null)) {
                        cont = 0;
                    } else {

                        if (query == "Shape") {
                            temp1 = space1.Shape;
                            temp2 = space2.Shape;

                            if ((Shape)temp1 == (Shape)temp2) {
                                cont++;
                                if (cont == 3) {
                                    winCondition = temp2;
                                    isLooping = false;
                                    break;
                                }
                            } else {
                                cont = 0;
                            }
                        } else {
                            temp1 = space1.Color;
                            temp2 = space2.Color;

                            if ((Color)temp1 == (Color)temp2) {
                                cont++;
                                if (cont == 3) {
                                    winCondition = temp2;
                                    isLooping = false;
                                    break;
                                }
                            } else {
                                cont = 0;
                            }
                        }
                    }
                }
                if (!isLooping) break;
            }
            return winCondition;
        }
    }
}
