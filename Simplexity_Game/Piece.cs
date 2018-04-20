namespace Simplexity_Game {

    /// <summary>
    /// Class that creates a piece
    /// </summary>
    public class Piece {
        //Properties
        public Color Color { get; }
        public Shape Shape { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Piece{T}"/> class.
        /// </summary>
        public Piece(Color color, Shape shape) {
            Color = color;
            Shape = shape;
        }
    }
}