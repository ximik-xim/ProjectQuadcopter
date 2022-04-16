using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Chunk : MonoBehaviour 
    {
        private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

        public float Size { get; private set; }

        public void Construct()
        {
            Size = GetComponentInChildren<MeshRenderer>().bounds.size.z;
            _spawnPoints.AddRange(GetComponentsInChildren<SpawnPoint>());
        }

        public void GenerateWindows()
        {

        }
    }
}