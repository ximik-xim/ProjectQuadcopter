using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : MultiplePrefabActorFactory<Chunk>
    {
        private WayMatrix _wayMatrix;
        SpawnMethod _spawnMethod;

        public ChunkFactory(IEnumerable<Chunk> prefabs, Container container, WayMatrix wayMatrix, SpawnMethod spawnMethod) : base(prefabs, container)
        {
            _prefabIndex = 0;
            _wayMatrix = wayMatrix;
            _spawnMethod = spawnMethod;
        }

        public override Chunk GetCreated()
        {
            Chunk chunk = Object.Instantiate(GetPrefab(), _container.transform);
            Disappearer disappearer = chunk.gameObject.AddComponent<Disappearer>();
            chunk.gameObject.AddComponent<Mover>();
            disappearer.OnDisappear += _spawnMethod;
            disappearer.SetDisappearPoint(new Vector3(_wayMatrix.Center.x, _wayMatrix.Center.y, _wayMatrix.Center.z - chunk.Size));
            return chunk;
        }
    }
}
