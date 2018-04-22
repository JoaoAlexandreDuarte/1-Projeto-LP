namespace Simplexity_Game {
    /// <summary>
    /// Class that contains the main method
    /// </summary>
    public class Program {
        /// <summary>
        /// Main method that initializes the Game
        /// </summary>
        static void Main(string[] args) {
            // Creates an instance of GameLoop to start the game
            GameLoop gameLoop = new GameLoop();
            // Calls the Update method to update the game
            gameLoop.Update();
        }
    }
}
