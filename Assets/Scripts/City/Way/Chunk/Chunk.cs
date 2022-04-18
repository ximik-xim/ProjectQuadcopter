using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Chunk : Actor 
    {
        public event SpawnHandler OnDisappear;

        private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

        public float Size { get; private set; }
        public Vector3 ConnectPosition { get; private set; }

        private void Awake()
        {
            Size = GetComponentInChildren<MeshRenderer>().bounds.size.z;
            ConnectPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + Size);
            _spawnPoints.AddRange(GetComponentsInChildren<SpawnPoint>());
        }

        public void GenerateWindows()
        {

        }
    }
}