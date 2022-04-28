using System;
using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public class RadiusableDetectorTarget : MonoBehaviour
    {
        public event Action<GameObject> Detecting;

        [SerializeField] [Range(1, 10)] private float _radius;

        private Quadcopter _target;
        private bool _isDetection = true;

        public float Radius => _radius;
        public Quadcopter Target => _target;

        private void OnEnable() => UpdateService.OnUpdate += Detect;

        public void SetTarget(Quadcopter target) => _target = target;

        private void Detect()
        {
            if (IsTargetInRadius() && _isDetection)
            {
                Detecting?.Invoke(_target.gameObject);
                _isDetection = false;
            }

            if (IsTargetInRadius() == false && _isDetection == false)
                _isDetection = true;
        }

        private bool IsTargetInRadius()
        {
            if (Vector3.Distance(transform.position, Target.transform.position) <= Radius)
                return true;

            return false;
        }

        private void OnDisable() => UpdateService.OnUpdate -= Detect;

        private void OnDrawGizmos()
        {
            if (gameObject.activeSelf)
            {
                float distance = Vector3.Distance(transform.position, _target.gameObject.transform.position);
                Vector3 valueOneDistance = transform.position / distance;
                Vector3 directionTarget = transform.position - valueOneDistance * _radius;

                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(transform.position, directionTarget);
            }
        }

    }
}