namespace Simplexity_Game {

    /// <summary>
    /// Class that creates a piece
    /// </summary>
    class Piece {
        //Properties
        public Color Color { get; }
        public Shape Shape { get; }

        /// <summary>
        /// A constructor that builds a piece object
        /// </summary>
        public Piece(Color color, Shape shape) {
            Color = color;
            Shape = shape;
        }
    }
}