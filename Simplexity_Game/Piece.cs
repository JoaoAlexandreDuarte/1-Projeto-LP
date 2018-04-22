namespace Simplexity_Game {

    /// <summary>
    /// Class that creates a piece
    /// </summary>
    public class Piece {
        //Properties
        /// <summary>
        /// Color of the piece
        /// </summary>
        public Color Color { get; }
        /// <summary>
        /// Shape of the piece
        /// </summary>
        public Shape Shape { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Piece"/> class.
        /// </summary>
        public Piece(Color color, Shape shape) {
            Color = color;
            Shape = shape;
        }
    }
}