using UnityEngine;

namespace Assets.Scripts
{
    public class SpeedProvider : MonoBehaviour
    {
        private const float SpeedUpValue = 0.0001f;

        public static float Speed { get; private set; }

        public void SetStartSpeed(float startSpeed) => Speed = startSpeed;

        private void OnEnable() => UpdateService.OnUpdate += SpeedUp;

        private void SpeedUp() => Speed += SpeedUpValue * Time.deltaTime;

        private void OnDisable() => UpdateService.OnUpdate -= SpeedUp;
    }
}