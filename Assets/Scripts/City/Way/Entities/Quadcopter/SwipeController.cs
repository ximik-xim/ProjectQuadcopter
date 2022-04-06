using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class SwipeController : MonoBehaviour
    {
        [SerializeField] [Range(0.5f, 5)] private float _stepSize;
        [SerializeField] [Range(0, 1)] private float _motionDuration;

        private int _currentPositionX;
        private int _currentPositionY;

        public int CurrentPositionX
        {
            get => _currentPositionX;

            private set => _currentPositionX = Mathf.Clamp(value, 0, Way.Matrix.Width - 1);
        }

        public int CurrentPositionY
        {
            get => _currentPositionY;

            private set => _currentPositionY = Mathf.Clamp(value, 0, Way.Matrix.Height - 1);
        }

        private void OnEnable() => SwipeHandler.OnSwipe += Move;

        public void Move(SwipeDirection swipeDirection)
        {
            switch (swipeDirection)
            {
                case SwipeDirection.Up:
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

                case SwipeDirection.Down:
                    CurrentPositionY++;
                    break;
            }

            UpdatePosition();
        }

        private void UpdatePosition() => transform.DOMove(Way.Matrix.GetPosition(CurrentPositionX, CurrentPositionY), _motionDuration);

        private void OnDisable() => SwipeHandler.OnSwipe -= Move;
    }
}