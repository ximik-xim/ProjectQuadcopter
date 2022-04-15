using UnityEngine;

namespace Assets.Scripts
{
    public class SpeedService : MonoBehaviour
    {
        private const float SpeedUpValue = 0.001f;

        public static float Speed { get; private set; }

        public static void SetStartSpeed(float startSpeed) => Speed = startSpeed;

        private void OnEnable() => UpdateService.OnFixedUpdate += SpeedUp;

        private void SpeedUp() => Speed += SpeedUpValue * Time.fixedDeltaTime;

        private void OnDisable() => UpdateService.OnFixedUpdate -= SpeedUp;
    }
}