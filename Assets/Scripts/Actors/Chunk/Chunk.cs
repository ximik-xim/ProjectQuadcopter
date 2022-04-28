using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Chunk : Actor 
    {
        private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

        public float Size { get; private set; }
        public Vector3 ConnectPosition => new Vector3(transform.position.x, transform.position.y, transform.position.z + Size);

        private void Awake()
        {
            Size = GetComponentInChildren<MeshRenderer>().bounds.size.z;
            _spawnPoints.AddRange(GetComponentsInChildren<SpawnPoint>());
        }

        public void SetWindows(EntitySpawner entitySpawner)
        {
            float density = 50;

            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                if (Random.Range(0, 100) > density) continue;
                Net net = entitySpawner.NetPool.Get(spawnPoint.transform.position);
            }
        }
    }
}