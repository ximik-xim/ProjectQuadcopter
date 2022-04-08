using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : IFactory<Chunk>
    {
        private List<Chunk> _prefabs;
        private Container _container;
        private int _prefabIndex = -1;
        private SpawnMethod _spawnMethod;

        public ChunkFactory(List<Chunk> prefabs, Container container, SpawnMethod spawnMethod)
        {
            _prefabs = prefabs;
            _container = container;
            _spawnMethod = spawnMethod;
        }

        public Chunk GetCreated()
        {
            _prefabIndex++;

            if (_prefabIndex == _prefabs.Count)
                _prefabIndex = 0;

            Chunk chunk = Object.Instantiate(_prefabs[_prefabIndex], _container.transform);
            chunk.OnStop += _spawnMethod;
            return chunk;
        }
    }
}
