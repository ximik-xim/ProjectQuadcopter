using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : IFactory<Chunk>
    {
        private List<Chunk> _prefabs;
        private Container _container;
        private int _prefabIndex = 0;
        private WayMatrix _wayMatrix;
        SpawnMethod _spawnMethod;

        public ChunkFactory(IEnumerable<Chunk> prefabs, Container container, WayMatrix wayMatrix, SpawnMethod spawnMethod)
        {
            _prefabs = new List<Chunk>(prefabs);
            _container = container;
            _wayMatrix = wayMatrix;
            _spawnMethod = spawnMethod;
        }

        public Chunk GetCreated()
        {
            _prefabIndex = (_prefabIndex == _prefabs.Count) ? 0 : _prefabIndex;
            Chunk chunk = Object.Instantiate(_prefabs[_prefabIndex], _container.transform);
            Disappearer disappearer = chunk.GetComponent<Disappearer>();
            _prefabIndex++;
            disappearer.OnDisappear += _spawnMethod;
            disappearer.SetDisappearPoint(new Vector3(_wayMatrix.Center.x, _wayMatrix.Center.y, _wayMatrix.Center.z - chunk.Size));
            return chunk;
        }
    }
}
