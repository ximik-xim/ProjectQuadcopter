using UnityEngine;

namespace Assets.Scripts
{
    class QuadcopterFactory : EntityFactory<Quadcopter>
    {
        private Vector3 _spawnPosition;

        public QuadcopterFactory(Quadcopter prefab, Container container, Vector3 spawnPosition) : base(prefab, container)
        {
            _spawnPosition = spawnPosition;
        }

        public override Quadcopter GetCreated()
        {
            return Object.Instantiate(_prefab, _spawnPosition, Quaternion.identity, _container.transform);
        }
    }
}
