using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Movable : Actor
    {
        public event SpawnMethod OnStop;

        [SerializeField] [Range(0, 10)] protected float _selfSpeed;

        protected WayMatrix _wayMatrix = new WayMatrix();

        protected void OnEnable() => UpdateService.OnFixedUpdate += Move;

        protected void Move()
        {
            transform.position += Vector3.back * (SpeedProvider.Speed + _selfSpeed);

            if (transform.position.z <= _wayMatrix.Edge)
            {
                gameObject.SetActive(false);
                OnStop?.Invoke();
            }
        }

        protected void OnDisable() => UpdateService.OnFixedUpdate -= Move;
    }
}