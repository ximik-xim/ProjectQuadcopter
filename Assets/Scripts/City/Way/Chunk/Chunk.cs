using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Chunk : Actor 
    {
        public event SpawnMethod OnDisappear;

        private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
        private Vector3 _disappearPoint;

        public float Size { get; private set; }
        public Vector3 ConnectPosition => new Vector3(transform.position.x, transform.position.y, transform.position.z + Size);

        private void Awake()
        {
            Size = GetComponentInChildren<MeshRenderer>().bounds.size.z;
            _spawnPoints.AddRange(GetComponentsInChildren<SpawnPoint>());
        }

        public void SetDisappearPoint(Vector3 disappearPoint) => _disappearPoint = disappearPoint;

        private void OnEnable() => UpdateService.OnUpdate += CheckEdgeOut;

        public void GenerateWindows()
        {

        }

        private void CheckEdgeOut()
        {
            if (transform.position.z <= _disappearPoint.z)
            {
                OnDisappear?.Invoke();
                gameObject.SetActive(false);
            }
        }

        private void OnDisable() => UpdateService.OnUpdate -= CheckEdgeOut;
    }
}