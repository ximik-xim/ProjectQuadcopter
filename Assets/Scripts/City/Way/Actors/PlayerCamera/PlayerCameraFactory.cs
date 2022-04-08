using UnityEngine;

namespace Assets.Scripts
{
    class PlayerCameraFactory : ActorFactory<PlayerCamera>
    {
        private Vector2 _position;

        public PlayerCameraFactory(PlayerCamera prefab, Container container, Vector2 position) : base(prefab, container)
        {
            _position = position;
        }

        public override PlayerCamera GetCreated()
        {
            return Object.Instantiate(_prefab, _position, Quaternion.identity, _container.transform);
        }
    }
}
