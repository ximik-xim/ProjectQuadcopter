using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : IFactory<Chunk>
    {
        private List<Chunk> _prefabs;
        private Container _container;
        private int _prefabIndex = -1;

        public ChunkFactory(List<Chunk> prefabs, Container container)
        {
            _prefabs = prefabs;
            _container = container;
        }

        public Chunk GetCreated()
        {
            _prefabIndex++;

            if (_prefabIndex == _prefabs.Count)
                _prefabIndex = 0;

            return Object.Instantiate(_prefabs[_prefabIndex], _container.transform);
        }
    }
}
