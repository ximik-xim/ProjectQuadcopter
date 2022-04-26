using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class SwipeController : MonoBehaviour
    {
        private float _motionDuration;
        private WayMatrix _wayMatrix;
        private int _currentPositionX;
        private int _currentPositionY;

        public int CurrentPositionX
        {
            get => _currentPositionX;

            private set => _currentPositionX = Mathf.Clamp(value, 0, _wayMatrix.Width - 1);
        }
        public int CurrentPositionY
        {
            get => _currentPositionY;

            private set => _currentPositionY = Mathf.Clamp(value, 0, _wayMatrix.Height - 1);
        }

        private void OnEnable() => SwipeHandler.OnSwipe += UpdatePosition;

        public void SetMatrix(WayMatrix wayMatrix) => _wayMatrix = wayMatrix;

        public void SetMotionDuration(float motionDuration) => _motionDuration = motionDuration;

        public void SetStartPosition(int x, int y)
        {
            CurrentPositionX = x;
            CurrentPositionY = y;
        }

        private void UpdatePosition(int x, int y)
        {
            CurrentPositionX += x;
            CurrentPositionY -= y;
            Move();
        }

        private void Move() => transform.DOMove(_wayMatrix.GetPosition(CurrentPositionX, CurrentPositionY), _motionDuration);

        private void OnDisable() => SwipeHandler.OnSwipe -= UpdatePosition;
    }
}