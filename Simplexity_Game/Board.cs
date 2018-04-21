namespace Simplexity_Game {
    /// <summary>
    /// Class that creates a board and places a piece in there
    /// </summary>
    public class Board {
        // X and Y of the array
        public int X { get; } = 7;
        public int Y { get; } = 7;
        // Bi-dimensional array that will serve as a board
        public Piece[,] BoardArray { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Board{T}"/> class.
        /// </summary>
        public Board() {
            BoardArray = new Piece[X, Y];
        }

        /// <summary>
        /// This method will try to place the piece on the given column and
        /// return true or false according to the possibilities
        /// </summary>
        public bool PlacePiece(Piece piece, int column) {
            // Starts at false to prevent an else condition
            bool canPlay = false;
            // Calls the private method to see where the piece will be placed
            int row = CheckColumn(column);

            // If the row is a possible one it will place the piece there
            if ((row >= 0) && (row < X)) {
                BoardArray[row, column] = piece;
                canPlay = true;
            }

            return canPlay;
        }

        /// <summary>
        /// This method will check at which position the piece can be placed 
        /// </summary>
        private int CheckColumn(int column) {
            // Starts at -1 so that it will return an error by default, any
            // value that's not between 0 and 6 can be considered an error
            // so we give it -1 because it's impossible to have negative values
            int row = -1;

            // Checks the given column for the spare space
            for (int i = 0; i < X; i++) {

                // If the current space is null it will break the cicle and 
                // return it
                if (BoardArray[i, column] == null) {
                    row = i;
                    break;
                }
            }

            return row;
        }
    }
}
