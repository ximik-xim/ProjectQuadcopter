using UnityEngine;

namespace Assets.Scripts
{
    public class WayMatrix
    {
        private Vector2[,] _matrix;

        public int Width { get; private set; } = 3;
        public int Height { get; private set; } = 3;
        public float Horizon { get; private set; }
        public float Spacing { get; private set; }

        public WayMatrix()
        {
            _matrix = new Vector2[Width, Height];
            Horizon = 50;
            Spacing = 5;

            float xCurrentIndex = -Spacing;
            float yCurrentIndex = Spacing;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
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

        public Vector2 GetPosition(int x, int y) => _matrix[x, y];
    }

    public enum MatrixPosition
    {
        UpperLeft,      Up,     UpperRight,

        Left,         Center,        Right,

        LowwerLeft,    Down,    LowwerRight
    }
}
