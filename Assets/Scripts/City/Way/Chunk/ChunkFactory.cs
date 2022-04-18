using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : IFactory<Chunk>
    {
        private List<Chunk> _prefabs;
        private Container _container;
        private int _prefabIndex = 0;

        public ChunkFactory(IEnumerable<Chunk> prefabs, Container container)
        {
            _prefabs = new List<Chunk>(prefabs);
            _container = container;
        }

        public Chunk GetCreated()
        {
            _prefabIndex = (_prefabIndex == _prefabs.Count) ? 0 : _prefabIndex;
            Chunk chunk = Object.Instantiate(_prefabs[_prefabIndex], _container.transform);
            _prefabIndex++;
            return chunk;
        }
    }
}
