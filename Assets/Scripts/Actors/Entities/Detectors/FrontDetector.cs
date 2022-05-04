using System;
using Assets.Scripts;
using UnityEngine;

public class FrontDetector : MonoBehaviour, IDetector
{
    public event Action OnDetect;

    private float _detectionDistance;
    private bool _isDetection = true;
    private void OnEnable() => UpdateService.OnUpdate += Detect;

    public void SetDetectionDistance(float range) => _detectionDistance = range;
    private void Detect()
    {
        if (IsTargetInRadius() && _isDetection)
        {
            OnDetect?.Invoke();
            _isDetection = false;
        }

        if (IsTargetInRadius() == false && _isDetection == false)
            _isDetection = true;
    }
    
    private bool IsTargetInRadius()
    {
        Ray ray = new Ray(transform.position, Vector3.back);
        Debug.DrawRay(ray.origin, ray.direction * _detectionDistance, Color.red);

        if (Physics.Raycast(ray.origin, ray.direction * _detectionDistance))  
            return true;

        return false;
    }

    private void OnDisable() => UpdateService.OnUpdate -= Detect;
}

