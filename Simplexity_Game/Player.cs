using System;
using System.Collections;

namespace Simplexity_Game {
    /// <summary>
    /// Class that creates the players and its pieces
    /// </summary>
    public class Player {
        // Constants that save the player color
        private const Color p1Color = Color.White;
        private const Color p2Color = Color.Red;
        // Property that will save the player's number
        public PlayerNumber Number { get; }
        // The given player pieces
        public Piece Cube { get; private set; }
        public Piece Cilinder { get; private set; }
        // The given player number of pieces
        public short CubesNumber { get; private set; }
        public short CilindersNumber { get; private set; }
        // The total number of the player pieces
        public short TotalPieces {
            get {
                return (short)(CubesNumber + CilindersNumber);
            }
        }

        /// <summary>
        /// Constructer for the Player according to it's number that also
        /// creates the given player pieces
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
        /// Returns a cube that can be "played" and decreases it's counter
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
        /// Returns a cilinder that can be "played" and decreases it's counter
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
