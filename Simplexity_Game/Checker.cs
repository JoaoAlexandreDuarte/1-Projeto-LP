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
            winCondition = CheckHorizontal(board, "Shape");
            if (winCondition == null) {
                winCondition = CheckVertical(board, "Shape");
            } else if (winCondition == null) {
                winCondition = CheckHorizontal(board, "Color");
            } else if (winCondition == null) {
                winCondition = CheckVertical(board, "Color");
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

        private Object CheckHorizontal(Board board, string query) {
            Object winCondition = null;
            bool isLooping = true;
            int cont = 0;
            Object temp1 = null, temp2 = null;
            Piece hor1, hor2;
            Piece vert1, vert2;

            for (int i = 0; i < board.X; i++) {
                for (int j = 0; j < board.Y - 1; j++) {

                    hor1 = board.BoardArray[i, j];
                    hor2 = board.BoardArray[i, j + 1];

                    if ((hor1 == null) || (hor2 == null)) {
                        cont = 0;
                    } else {

                        if (query == "Shape") {
                            temp1 = hor1.Shape;
                            temp2 = hor2.Shape;

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
                            temp1 = hor1.Color;
                            temp2 = hor2.Color;

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

        private Object CheckVertical(Board board, string query) {
            Object winCondition = null;
            bool isLooping = true;
            int cont = 0;
            Object temp1 = null, temp2 = null;
            Piece vert1, vert2;

            for (int i = 0; i < board.X; i++) {
                for (int j = 0; j < board.Y - 1; j++) {

                    vert1 = board.BoardArray[j, i];
                    vert2 = board.BoardArray[j + 1, i];

                    if ((vert1 == null) || (vert2 == null)) {
                        cont = 0;
                    } else {

                        if (query == "Shape") {
                            temp1 = vert1.Shape;
                            temp2 = vert2.Shape;

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
                            temp1 = vert1.Color;
                            temp2 = vert2.Color;

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
