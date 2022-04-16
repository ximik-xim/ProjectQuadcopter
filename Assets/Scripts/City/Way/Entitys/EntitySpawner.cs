using UnityEngine;

namespace Assets.Scripts
{
    public class EntitySpawner : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Quadcopter _quadcopterPrefab;
        [SerializeField] private PlayerCamera _playerCameraPrefab;
        [SerializeField] private AggressiveBird _aggressiveBurdPrefab;
        [SerializeField] private Car _carPrefab;
        [SerializeField] private Clothesline _clotheslinePrefab;
        [SerializeField] private Net _netPrefab;

        public Container EntitieContainer { get; private set; }

        public void Init(City city, WayMatrix wayMatrix)
        {
            EntitieContainer = ContainerService.GetCreatedContainer("EntityContainer", city.transform, Vector3.zero);
            GetCreatedEntity(new QuadcopterFactory(_quadcopterPrefab, EntitieContainer, wayMatrix));
            GetCreatedEntity(new PlayerCameraFactory(_playerCameraPrefab, EntitieContainer, wayMatrix.Center));
        }

        private E GetCreatedEntity<E>(EntityFactory<E> entityFactory) where E : Entity => entityFactory.GetCreated();
    }
}
