using System;
using System.Collections;

namespace Simplexity_Game {
    /// <summary>
    /// Class that creates the players and its pieces
    /// </summary>
    public class Player {
        // Property that will save the player's number
        public PlayerNumber Number { get; }
        // Property that will return the total pieces
        public int TotalPieces {
            get {
                return cubes.Count + cilinders.Count;
            }
        }
        // Saves the number os pieces available and then provides their count
        private Queue cubes = new Queue();
        private Queue cilinders = new Queue();

        /// <summary>
        /// Constructer for Player and its pieces
        /// </summary>
        public Player(PlayerNumber number) {
            Number = number;

            // Give cubes and cilinders to the players
            if (Number == PlayerNumber.One) {
                CreateCubes(Color.White);
                CreateCilinders(Color.White);
            }
            else {
                CreateCubes(Color.Red);
                CreateCilinders(Color.Red);
            }
        }

        /// <summary>
        ///  Will return the number of cubes
        /// </summary>
        /// <returns></returns>
        public int CubesNumber() {
            return cubes.Count;
        }

        /// <summary>
        /// Will return the number of cilinders
        /// </summary>
        /// <returns></returns>
        public int CilindersNumber() {
            return cilinders.Count;
        }

        /// <summary>
        /// Will remove a cube from the queue and return it
        /// </summary>
        /// <returns></returns>
        public Piece PlayCube() {
            return (Piece) cubes.Dequeue();
        }

        /// <summary>
        /// Will remove a cilinder from the queue and return it
        /// </summary>
        /// <returns></returns>
        public Piece PlayCilinder() {
            return (Piece) cilinders.Dequeue();
        }

        /// <summary>
        /// Method that will create the necessary cubes
        /// </summary>
        private void CreateCubes(Color color) {
            // The for cycle will add the cubes to the queue
            for (int i = 0; i < 11; i++) {
                cubes.Enqueue(new Piece(color, Shape.Cube));
            }
        }

        /// <summary>
        /// Method that will create the necessary cilinders
        /// </summary>
        private void CreateCilinders(Color color) {
            // The for cycle will add the cilinders to the queue
            for (int i = 0; i < 10; i++) {
                cilinders.Enqueue(new Piece(color, Shape.Cilinder));
            }
        }
    }
}
