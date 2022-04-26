using UnityEngine;

namespace Assets.Scripts
{
    class PlayerCameraFactory : ActorFactory<PlayerCamera>
    {
        public PlayerCameraFactory(PlayerCamera prefab, Container container, Vector2 position) : base(prefab, container, position) { }

        public override PlayerCamera GetCreated()
        {
            return Object.Instantiate(_prefab, _spawnPosition, Quaternion.identity, _container.transform);
        }
    }
}
