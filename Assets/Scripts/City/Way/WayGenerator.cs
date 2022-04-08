using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public delegate void SpawnMethod();

    public class WayGenerator : MonoBehaviour
    {
        private ChunkFactory _chunkFactory;
        private Pool<Chunk> _chunksPool;
        private WayMatrix _wayMatrix = new WayMatrix();
        private float _chunkSize;

        public void InitWay(List<Chunk> prefabs, Container container, int amount)
        {
            _chunkFactory = new ChunkFactory(prefabs, container, SpawnChunk, out _chunkSize);
            _chunksPool.Init(_chunkFactory, container, amount);
        }

        public void SpawnStartableChunks(int amount)
        {
            float spacing = 0;

            for (int i = 0; i < amount; i++)
            {
                _chunksPool.Get(new Vector3(_wayMatrix.Horizon.x, _wayMatrix.Horizon.y, _wayMatrix.Horizon.z + spacing));
                spacing -= _chunkSize;
            }
        }

        public void SpawnChunk() => _chunksPool.Get(_wayMatrix.Horizon);
    }
}