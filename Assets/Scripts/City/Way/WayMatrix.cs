using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Way Matrix", fileName = "New Way Matrix")]
    public class WayMatrix : ScriptableObject
    {
        [SerializeField] [Range(2, 10)] private int _width;
        [SerializeField] [Range(2, 10)] private int _height;
        [SerializeField] [Range(1, 10)] private float _spacing;

        private Vector2[,] _matrix;

        public int Width => _width;
        public int Height => _height;
        public float Spacing => _spacing;
        public Vector3 Center => _matrix[_width / 2, _height / 2];

        public void OnValidate()
        {
            _matrix = new Vector2[Width, Height];

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

        public Vector2 GetPosition(int x, int y) => _matrix[x, y];
    }
}
