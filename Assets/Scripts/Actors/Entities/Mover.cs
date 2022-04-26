using UnityEngine;

namespace Assets.Scripts
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] [Range(1, 100)] protected float _selfSpeed;

        protected void OnEnable() => UpdateService.OnFixedUpdate += Move;

        protected void Move() => transform.position += (SpeedService.Speed + _selfSpeed) * Time.fixedDeltaTime * Vector3.back;

        protected void OnDisable() => UpdateService.OnFixedUpdate -= Move;
    }
}