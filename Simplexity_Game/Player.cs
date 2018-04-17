using System;

namespace Simplexity_Game {
    /// <summary>
    /// Class that creates the players
    /// </summary>
    class Player {
        // Properties
        public PlayerNumber Number { get; }
        Piece[] cubes;
        Piece[] cilinders;

        /// <summary>
        /// Constructer for Player
        /// </summary>
        public Player(PlayerNumber playerNumber) {
            this.Number = playerNumber;

            cubes = new Piece[11];
            cilinders = new Piece[10];


            for (int i = 0; i < 11; i++) {
                cubes[0] = new Piece(Color.White, Shape.Cube);
            }
        }

    }
}
