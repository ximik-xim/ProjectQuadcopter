using UnityEngine;

namespace Assets.Scripts
{
    public class WayMatrix
    {
        private const int MatrixWidth = 3;
        private const int MatrixHeight = 3;
        private Vector2[,] _matrix;

        public float Horizon { get; private set; }
        public float Spacing { get; private set; }

        public WayMatrix(float horizon, float spacing)
        {
            _matrix = new Vector2[MatrixWidth, MatrixHeight];
            Horizon = horizon;
            Spacing = spacing;

            float xCurrentIndex = -Spacing;
            float yCurrentIndex = Spacing;

            for (int x = 0; x < MatrixWidth; x++)
            {
                for (int y = 0; y < MatrixHeight; y++)
                {
                    _matrix[x, y] = new Vector2(xCurrentIndex, yCurrentIndex);
                    yCurrentIndex -= Spacing;
                }

                xCurrentIndex += Spacing;
                yCurrentIndex = Spacing;
            }
        }

        public Vector2 GetPosition(MatrixPosition position)
        {
            switch (position)
            {
                case MatrixPosition.UpperLeft: return _matrix[0, 0];

                case MatrixPosition.Up: return _matrix[1, 0];

                case MatrixPosition.UpperRight: return _matrix[2, 0];

                case MatrixPosition.Left: return _matrix[0, 1];

                case MatrixPosition.Center: return _matrix[1, 1];

                case MatrixPosition.Right: return _matrix[2, 1];

                case MatrixPosition.LowwerLeft: return _matrix[0, 2];

                case MatrixPosition.Down: return _matrix[1, 2];

                case MatrixPosition.LowwerRight: return _matrix[2, 2];
            }

            return Vector2.zero;
        }
    }

    public enum MatrixPosition
    {
        UpperLeft,      Up,     UpperRight,

        Left,         Center,        Right,

        LowwerLeft,    Down,    LowwerRight
    }
}
