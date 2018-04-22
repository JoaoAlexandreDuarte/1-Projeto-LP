namespace Simplexity_Game {
    /// <summary>
    /// Class that creates the players and its pieces
    /// </summary>
    public class Player {
        // Constants that save the player's color
        private const Color p1Color = Color.White;
        private const Color p2Color = Color.Red;
        /// <summary>
        /// Property that will save the player's number
        /// </summary>
        public PlayerNumber Number { get; }
        /// <summary>
        /// The cubes given to the player
        /// </summary>
        public Piece Cube { get; private set; }
        /// <summary>
        /// The cilinders given to the player
        /// </summary>
        public Piece Cilinder { get; private set; }
        /// <summary>
        /// The number of cubes given to the player
        /// </summary>
        public short CubesNumber { get; private set; }
        /// <summary>
        /// The number of pieces given to the player
        /// </summary>
        public short CilindersNumber { get; private set; }
        /// <summary>
        /// The total number of pieces given to the player
        /// </summary>
        public short TotalPieces {
            get {
                return (short)(CubesNumber + CilindersNumber);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player(PlayerNumber number) {
            Number = number;
            // Sets the current color according to the given PlayerNumber
            Color currentColor = (number == PlayerNumber.One ?
                p1Color : p2Color);

            // Creates the pieces that can be played by the player
            Cube = new Piece(currentColor, Shape.Cube);
            Cilinder = new Piece(currentColor, Shape.Cilinder);

            // Initializes each piece's number
            CubesNumber = 11;
            CilindersNumber = 10;
        }

        /// <summary>
        /// Returns a cube that can be "played" and decreases its counter
        /// </summary>
        public Piece PlayCube() {
            Piece cube = null;

            // If the player has more than 0 cubes it will "play" one
            if (CubesNumber > 0) {
                CubesNumber--;
                cube = Cube;
            }
            return cube;
        }

        /// <summary>
        /// Returns a cilinder that can be "played" and decreases its counter
        /// </summary>
        public Piece PlayCilinder() {
            Piece cilinder = null;

            // If the player has more than 0 cilinders it will "play" one
            if (CilindersNumber > 0) {
                CilindersNumber--;
                cilinder = Cilinder;
            }

            return cilinder;
        }
    }
}
