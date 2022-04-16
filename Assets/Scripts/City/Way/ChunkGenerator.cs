using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public delegate void SpawnMethod(Vector3 position);

    public class ChunkGenerator : MonoBehaviour
    {
        [SerializeField] private List<Chunk> _chunkPrefabs;
        [Space(30)]
        [SerializeField] [Range(10, 500)] private float _horizon;
        [SerializeField][Range(1, 100)] private int _startableChunksAmount;

        private WayMatrix _wayMatrix;
        private Container _chunkContainer;
        private ChunkFactory _chunkFactory;
        private Pool<Chunk> _chunksPool;
        private Vector3 _spawnPosition;
        private EntitySpawner _entitySpawner;

        public void Init(City city, WayMatrix wayMatrix, EntitySpawner entitySpawner)
        {
            _wayMatrix = wayMatrix;
            _entitySpawner = entitySpawner;
            _spawnPosition = new Vector3(_wayMatrix.Center.x, _wayMatrix.Center.y, _horizon);
            _chunkContainer = ContainerService.GetCreatedContainer("ChunkContainer", city.transform, _spawnPosition);
            _chunkFactory = new ChunkFactory(_chunkPrefabs, _chunkContainer);
            _chunksPool = new Pool<Chunk>(_chunkFactory, _chunkContainer, _chunkPrefabs.Count);
            GenerateStartableChunks(_startableChunksAmount);
        }

        private void GenerateStartableChunks(int amount)
        {
            Vector3 spawnPosition = _spawnPosition;

            for (int i = 0; i < amount; i++)
            {
                Chunk spawnedChunk = GetSpawnedChunk(spawnPosition);
                spawnPosition.z -= spawnedChunk.Size;
            }
        }

        public Chunk GetSpawnedChunk(Vector3 position)
        {
            Chunk spawnedChunk =  _chunksPool.Get(position);
            spawnedChunk.GenerateWindows();
            return spawnedChunk;
        }
    }
}