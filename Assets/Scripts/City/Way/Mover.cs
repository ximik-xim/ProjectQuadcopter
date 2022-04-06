using UnityEngine;

namespace Assets.Scripts
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] [Range(0, 10)] float _selfSpeed;

        private float _motionTimeLimit = 5;
        private float _motionTime = 0;

        public float MotionTime
        {
            get => _motionTime;

            set
            {
                _motionTime = value;

                if (value >= _motionTimeLimit)
                {
                    _motionTime = 0;
                    gameObject.SetActive(false);
                }
            }
        }

        private void OnEnable() => UpdateService.OnFixedUpdate += Move;

        private void Move()
        {
            MotionTime += Time.fixedDeltaTime;
            transform.position += Vector3.back * (Way.Speed + _selfSpeed);
        }

        private void OnDisable() => UpdateService.OnFixedUpdate -= Move;
    }
}