using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Assets.Scripts
{
    public class SwipeHandler : MonoBehaviour
    {
        public event Action<SwipeDirection> OnSwipe;

        [SerializeField] [Range(0, 1)] private float _directionThreshold;
        [SerializeField] [Range(0, 300)] private int _deadZone;

        public Vector2 StartContact { get; private set; }
        public Vector2 EndContact { get; private set; }
        
        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            Touch.onFingerDown += callbackContext => StartSwipe();
            Touch.onFingerUp += callbackContext => EndSwipe();
        }

        private void StartSwipe() => StartContact = Touch.activeFingers[0].currentTouch.startScreenPosition;

        private void EndSwipe()
        {
            EndContact = Touch.activeFingers[0].currentTouch.screenPosition;
            Vector2 swipeDirection = (EndContact - StartContact);

            if (swipeDirection.magnitude >= _deadZone)
                OnSwipe?.Invoke(DeterminateDirection(swipeDirection.normalized));
        }

        private SwipeDirection DeterminateDirection(Vector2 swipeDirection)
        {
            if (Vector2.Dot((Vector2.up + Vector2.left).normalized, swipeDirection) > _directionThreshold) return SwipeDirection.UpperLeft;

            if (Vector2.Dot(Vector2.up, swipeDirection) > _directionThreshold) return SwipeDirection.Up;

            if (Vector2.Dot((Vector2.up + Vector2.right).normalized, swipeDirection) > _directionThreshold) return SwipeDirection.UpperRight;

            if (Vector2.Dot(Vector2.left, swipeDirection) > _directionThreshold) return SwipeDirection.Left;

            if (Vector2.Dot(Vector2.right, swipeDirection) > _directionThreshold) return SwipeDirection.Right;

            if (Vector2.Dot((Vector2.down + Vector2.left).normalized, swipeDirection) > _directionThreshold) return SwipeDirection.LowwerLeft;

            if (Vector2.Dot(Vector2.down, swipeDirection) > _directionThreshold) return SwipeDirection.Down;

            if (Vector2.Dot((Vector2.down + Vector2.right).normalized, swipeDirection) > _directionThreshold) return SwipeDirection.LowwerRight;

            return SwipeDirection.Zero;
        }

        private void OnDisable() => EnhancedTouchSupport.Disable();
    }

    public enum SwipeDirection
    {
        UpperLeft,      Up,     UpperRight,

        Left,         Zero,          Right,

        LowwerLeft,   Down,     LowwerRight
    }
}