using UnityEngine;

public class WayMatrixNew
{
    private const int _width = 3;
    private const int _height = 3;
    [SerializeField] [Range(1, 10)] private float _spacing;

    private Vector2[,] _matrix;

    public int Width => _width;
    public int Height => _height;
    public float Spacing => _spacing;

    public WayMatrixNew()
    {
        _matrix = new Vector2[Height, Width];
        float xPositionValue = Spacing;

        for (int x = 0; x < Height; x++)
        {
            float yPositionValue = -Spacing;

            for (int y = 0; y < Width; y++)
            {
                _matrix[x, y] = new Vector2(yPositionValue, xPositionValue);
                yPositionValue += Spacing;
            }

            xPositionValue -= Spacing;
        }
    }

    public void PrintMatrix()
    {
        string matrixOut = "\n";

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                matrixOut += "(" + _matrix[x, y].x + "," + _matrix[x, y].y + ")" + " ";
            }

            matrixOut += "\n";
        }

        Debug.Log(matrixOut);
    }

    public Vector3 GetPosition(PositionType position)
    {
        switch (position)
        {
            case PositionType.UpLeft:
                {
                    return _matrix[0, 0];
                }
            case PositionType.UpRight:
                {
                    return _matrix[0, Width - 1];
                }
            case PositionType.Center:
                {
                    return _matrix[Height / 2, Width / 2];
                }
            case PositionType.DownLeft:
                {
                    return _matrix[Height - 1, 0];
                }
            case PositionType.DownRight:
                {
                    return _matrix[Height - 1, Width - 1];
                }
            default:
                {
                    goto case PositionType.Center;
                }
        }
    }

    public Vector3[] GetRowWithIndex(int rowIndex)
    {
        Vector3[] matrixRow = new Vector3[Width];

        for (int i = 0; i < Width; i++)
        {
            matrixRow[i] = _matrix[rowIndex, i];
        }

        return matrixRow;
    }

    public enum PositionType
    {
        UpLeft,
        UpRight,
        Center,
        DownLeft,
        DownRight
    }
}
