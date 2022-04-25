using UnityEngine;

namespace Assets.Scripts
{
    public class DistanceMeter : MonoBehaviour
    {
        private int _distance;

        public string Distance { get; private set; }

        private void OnEnable() => UpdateService.OnUpdate += CalculateDistance;

        private void CalculateDistance()
        {
            _distance += (int)(Time.deltaTime * SpeedService.Speed);
        }

        private void OnDisable() => UpdateService.OnUpdate -= CalculateDistance;
    }
}