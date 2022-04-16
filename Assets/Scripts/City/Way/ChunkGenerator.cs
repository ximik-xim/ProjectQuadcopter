using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public delegate void SpawnMethod(Vector3 position);

    public class ChunkGenerator : MonoBehaviour
    {
        [SerializeField] [Range(10, 500)] private float _horizon;

        private WayMatrix _wayMatrix;
        private Container _chunkContainer;
        private ChunkFactory _chunkFactory;
        private Pool<Chunk> _chunksPool;
        private float _chunkSize;
        private Vector3 _spawnPosition;

        public void Init(City city, WayMatrix wayMatrix, List<Chunk> prefabs, int startableChunksAmount)
        {
            _wayMatrix = wayMatrix;
            _spawnPosition = new Vector3(_wayMatrix.Center.x, _wayMatrix.Center.y, _horizon);
            _chunkContainer = ContainerService.GetCreatedContainer("ChunkContainer", city.transform, _spawnPosition);
            _chunkFactory = new ChunkFactory(prefabs, _chunkContainer, out _chunkSize);
            _chunksPool.Init(_chunkFactory, _chunkContainer, prefabs.Count);
            GenerateStartableChunks(startableChunksAmount);
        }

        private void GenerateStartableChunks(int amount)
        {
            Vector3 spawnPosition = _spawnPosition;

            for (int i = 0; i < amount; i++)
            {
                GetSpawnedChunk(spawnPosition);
                spawnPosition.z -= _chunkSize;
            }
        }

        public Chunk GetSpawnedChunk(Vector3 position) => _chunksPool.Get(position);
    }
}