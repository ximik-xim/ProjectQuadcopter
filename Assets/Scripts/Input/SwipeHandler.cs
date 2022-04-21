using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Assets.Scripts
{
    public class SwipeHandler : MonoBehaviour
    {
        public static event Action<int, int> OnSwipe;

        [SerializeField] [Range(0, 1000)] private int _deadZone;

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
            {
                CalculateDirection(swipeDirection.normalized, out int x, out int y);
                OnSwipe?.Invoke(x, y);
            }
        }

        private void CalculateDirection(Vector2 normalizedSwipeDirection, out int x, out int y)
        {
            x = Mathf.RoundToInt(normalizedSwipeDirection.x - 0.2f * Mathf.Sign(normalizedSwipeDirection.x));
            y = Mathf.RoundToInt(normalizedSwipeDirection.y - 0.2f * Mathf.Sign(normalizedSwipeDirection.y));
        }

        private void OnDisable() => EnhancedTouchSupport.Disable();
    }
}