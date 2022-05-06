using UnityEngine;

namespace Assets.Scripts
{
    public class SpeedService : MonoBehaviour
    {
        //private const float SpeedUpValue = 0.05f;//0.0005f

        public static float Speed { get; private set; }
        public static float Acceleration { get => 0.0005f; }

        public static void SetStartSpeed(float startSpeed) => Speed = startSpeed;

        private void OnEnable() => UpdateService.OnFixedUpdate += SpeedUp;

        public static void SpeedUp() => Speed += Acceleration * Time.fixedDeltaTime;

        private void OnDisable() => UpdateService.OnFixedUpdate -= SpeedUp;
    }
}