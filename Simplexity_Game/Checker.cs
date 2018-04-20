using System;

namespace Simplexity_Game {
    /// <summary>
    /// Class that will check if there's a win condition on the board
    /// </summary>
    class Checker {

        /// <summary>
        /// Constructor for Checker
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

            winCondition = CheckHorizontal(board, "Shape");
            if (winCondition == null) winCondition = CheckHorizontal(board,
                "Color");


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
            Shape shape1, shape2;
            Color color1, color2;

            for (int i = 0; i < board.X; i++) {
                for (int j = 0; j < board.Y - 1; j++) {

                    if ((board.BoardArray[i, j] == null) ||
                        (board.BoardArray[i, j + 1] == null)) {

                        cont = 0;
                    } else {
                        shape1 = board.BoardArray[i, j].Shape;
                        color1 = board.BoardArray[i, j].Color;
                        shape2 = board.BoardArray[i, j + 1].Shape;
                        color2 = board.BoardArray[i, j + 1].Color;

                        if (query == "Shape") {
                            temp1 = shape1;
                            temp2 = shape2;

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
                            temp1 = color1;
                            temp2 = color2;

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

        private Object CheckVertical() {

            return null;
        }
    }
}
