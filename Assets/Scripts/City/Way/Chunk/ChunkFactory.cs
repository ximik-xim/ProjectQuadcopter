using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : IFactory<Chunk>
    {
        private List<Chunk> _prefabs;
        private Container _container;
        private int _prefabIndex = -1;

        public ChunkFactory(List<Chunk> prefabs, Container container, out float chunkSize)
        {
            _prefabs = prefabs;
            _container = container;
            chunkSize = _prefabs[0].Size;
        }

        public Chunk GetCreated()
        {
            _prefabIndex++;

            if (_prefabIndex == _prefabs.Count)
                _prefabIndex = 0;

            Chunk chunk = Object.Instantiate(_prefabs[_prefabIndex], _container.transform);
            return chunk;
        }
    }
}
