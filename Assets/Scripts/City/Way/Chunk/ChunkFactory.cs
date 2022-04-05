using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : IFactory<Chunk>
    {
        private List<Chunk> _prefabs;
        private Container _container;

        public ChunkFactory(List<Chunk> prefabs, Container container)
        {
            _prefabs = prefabs;
            _container = container;
        }

        public Chunk GetCreated() => Object.Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], _container.transform);
    }
}
