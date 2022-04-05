using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class SwipeController : MonoBehaviour
    {
        [SerializeField] [Range(0.5f, 5)] private float _stepSize;
        [SerializeField] [Range(0, 1)] private float _motionDuration;

        private const int MotionMapWidth = 3;
        private const int MotionMapHeight = 3;

        private SwipeHandler _swipeHandler;
        private Vector2[,] _motionMap = new Vector2[MotionMapWidth, MotionMapHeight];
        private int _currentPositionX = 1;
        private int _currentPositionY = 1;

        public int CurrentPositionX 
        {
            get => _currentPositionX;

            private set => _currentPositionX = Mathf.Clamp(value, 0, _motionMap.GetLength(0) - 1);
        }

        public int CurrentPositionY 
        { 
            get => _currentPositionY;

            private set => _currentPositionY = Mathf.Clamp(value, 0, _motionMap.GetLength(1) - 1);
        }

        private void Awake() => InitMotionMap();

        private void OnEnable() => _swipeHandler.OnSwipe += Move;

        private void InitMotionMap()
        {
            float xStep = -1;
            float yStep = 1;

            for (int x = 0; x < MotionMapWidth; x++)
            {
                for (int y = 0; y < MotionMapHeight; y++)
                {
                    _motionMap[x, y] = new Vector2(xStep, yStep);
                    yStep -= _stepSize;
                }

                xStep += _stepSize;
                yStep = 1;
            }
        }

        private void Move(SwipeDirection swipeDirection)
        {
            switch (swipeDirection)
            {
                case SwipeDirection.UpperLeft:
                    CurrentPositionX--;
                    CurrentPositionY--;
                    break;

                case SwipeDirection.Up:
                    CurrentPositionY--;
                    break;

                case SwipeDirection.UpperRight:
                    CurrentPositionX++;
                    CurrentPositionY--;
                    break;

                case SwipeDirection.Left:
                    CurrentPositionX--;
                    break;

                case SwipeDirection.Zero:
                    break;

                case SwipeDirection.Right:
                    CurrentPositionX++;
                    break;

                case SwipeDirection.LowwerLeft:
                    CurrentPositionX--;
                    CurrentPositionY++;
                    break;

                case SwipeDirection.Down:
                    CurrentPositionY++;
                    break;

                case SwipeDirection.LowwerRight:
                    CurrentPositionX++;
                    CurrentPositionY++;
                    break;
            }

            UpdatePosition();
        }

        private void UpdatePosition() => transform.DOMove(_motionMap[CurrentPositionX, CurrentPositionY], _motionDuration);

        private void OnDisable() => _swipeHandler.OnSwipe -= Move;
    }
}