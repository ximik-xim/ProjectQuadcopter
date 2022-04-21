using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public delegate void RadiusEnterHandler();

    public class RadiusableDetector : MonoBehaviour
    {
        public event RadiusEnterHandler OnRadiusEnter;

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
                OnRadiusEnter?.Invoke();
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
    }

    [CustomEditor(typeof(RadiusableDetector))]
    public class TargetDetectorEditor : Editor
    {
        private void OnSceneGUI()
        {
            RadiusableDetector detector = target as RadiusableDetector;
            Handles.color = Color.red;
            Handles.DrawWireArc(detector.transform.position, Vector3.up, Vector3.forward, 360, detector.Radius);
        }
    }
}