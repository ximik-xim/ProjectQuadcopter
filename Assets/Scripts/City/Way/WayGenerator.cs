using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WayGenerator : MonoBehaviour
    {
        private Coroutine _loopRoutine;
        private ChunkFactory _chunkFactory;
        private Pool<Chunk> _chunksPool;

        public void StartLoop() => _loopRoutine = StartCoroutine(LoopRoutine());

        public void GenerateChunks(List<Chunk> prefabs, Container container, int amount)
        {
            _chunkFactory = new ChunkFactory(prefabs, container);
            _chunksPool.Init(_chunkFactory, container, amount);
        }

        private IEnumerator LoopRoutine()
        {
            float spawnTemp = 1.5f;

            while (true)
            {
                _chunksPool.Get();
                yield return new WaitForSeconds(spawnTemp * SpeedProvider.Speed);
            }
        }

        private void OnDisable() => StopCoroutine(_loopRoutine);
    }
}