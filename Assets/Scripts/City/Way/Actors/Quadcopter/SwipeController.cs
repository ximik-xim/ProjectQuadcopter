using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class SwipeController : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float _motionDuration;
        private WayMatrix _wayMatrix;
        private int _currentPositionX = 1;
        private int _currentPositionY = 1;

        private void OnEnable() => SwipeHandler.OnSwipe += Move;

        public void SetMatrix(WayMatrix wayMatrix) => _wayMatrix = wayMatrix;

        public void Move(int x, int y)
        {
            Debug.Log(_currentPositionX + " " + _currentPositionY);
            Debug.Log($"{x} : {y}");
            _currentPositionX += Mathf.Clamp(x, 0, _wayMatrix.Width - 1);
            _currentPositionY += Mathf.Clamp(y, 0, _wayMatrix.Height - 1);
            Debug.Log(_currentPositionX + " " + _currentPositionY);
            UpdatePosition();
        }

        private void UpdatePosition() => transform.DOMove(_wayMatrix.GetPosition(_currentPositionX, _currentPositionY), _motionDuration);

        private void OnDisable() => SwipeHandler.OnSwipe -= Move;
    }
}