using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : ActorFactory<Chunk, ChunkConfig>
    {
        private WayMatrix _wayMatrix;
        private SpawnMethod _spawnMethod;
        private EntitySpawner _entitySpawner;

        public ChunkFactory(ChunkConfig config, Container container, WayMatrix wayMatrix, SpawnMethod spawnMethod, EntitySpawner entitySpawner) : base(config, container)
        {
            _wayMatrix = wayMatrix;
            _spawnMethod = spawnMethod;
            _entitySpawner = entitySpawner;
        }

        public override Chunk GetCreated()
        {
            Chunk chunk = Object.Instantiate(_config.Prefab, _container.transform);
            Disappearer disappearer = chunk.gameObject.AddComponent<Disappearer>();
            chunk.gameObject.AddComponent<Mover>();
            disappearer.OnDisappear += _spawnMethod;
            disappearer.SetDisappearPoint(new Vector3(_wayMatrix.Center.x, _wayMatrix.Center.y, _wayMatrix.Center.z - chunk.Size));
            return chunk;
        }
    }
}
