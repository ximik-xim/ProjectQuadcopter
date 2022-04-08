using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public delegate void SpawnMethod();

    public class WayGenerator : MonoBehaviour
    {
        private ChunkFactory _chunkFactory;
        private Pool<Chunk> _chunksPool;

        public void InitWay(List<Chunk> prefabs, Container container, int amount)
        {
            _chunkFactory = new ChunkFactory(prefabs, container, SpawnChunk);
            _chunksPool.Init(_chunkFactory, container, amount);
            SpawnStartChunksToHorizon();
        }

        private void SpawnStartChunksToHorizon()
        {

        }

        public void SpawnChunk() => _chunksPool.Get();
    }
}