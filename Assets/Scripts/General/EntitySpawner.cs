using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EntitySpawner : MonoBehaviour
    {
        private WayMatrix _wayMatrix = new WayMatrix();
        private Dictionary<Type, IPool> _pools = new Dictionary<Type, IPool>();

        [Header("Configurations")]
        [SerializeField] private QuadcopterConfig _quadcopterConfig;
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private AggressiveBirdConfig _aggressiveBirdConfig;
        [SerializeField] private CarConfig _carConfig;
        [SerializeField] private ClotheslineConfig _clotheslineConfig;
        [SerializeField] private NetGuyConfig _netGuyConfig;

        [Header("SpawnDensity")]
        [SerializeField][Range(0, 100)] private int _aggressiveBirdDensity;
        [SerializeField][Range(0, 100)] private int _carDensity;
        [SerializeField][Range(0, 100)] private int _clothesLineDensity;
        [SerializeField][Range(0, 100)] private int _netGuyDensity;

        public int AggressiveBirdDensity => _aggressiveBirdDensity;
        public int CarDensity => _carDensity;
        public int ClotheslineDensity => _clothesLineDensity;
        public int NetGuyDensity => _netGuyDensity;

        public Container EntitiesContainer { get; private set; }

        public void Init(City city)
        {
            EntitiesContainer = ContainerService.GetCreatedContainer("Entities", city.transform, Vector3.zero);

            Quadcopter quadcopter = GetCreatedEntity(new QuadcopterFactory(_quadcopterConfig, EntitiesContainer));
            GetCreatedEntity(new PlayerCameraFactory(_playerCameraConfig, EntitiesContainer, _wayMatrix.GetPosition(MatrixPosition.Center)));

            _pools[typeof(AggressiveBird)] = new Pool<AggressiveBird>(new AggressiveBirdFactory(_aggressiveBirdConfig, quadcopter), EntitiesContainer, 10);
            _pools[typeof(Car)] = new Pool<Car>(new CarFactory(_carConfig, quadcopter), EntitiesContainer, 10);
            _pools[typeof(Clothesline)] = new Pool<Clothesline>(new ClotheslineFactory(_clotheslineConfig, quadcopter), EntitiesContainer, 10);
            _pools[typeof(NetGuy)] = new Pool<NetGuy>(new NetGuyFactory(_netGuyConfig, quadcopter), EntitiesContainer, 10);
            StartCoroutine(SpawnEntities());
        }

        public Pool<T> GetPool<T>() where T : Actor => _pools[typeof(T)] as Pool<T>;

        private E GetCreatedEntity<E>(IFactory<E> entityFactory) where E : Entity => entityFactory.GetCreated();

        private IEnumerator SpawnEntities()
        {
            while (true)
            {
                SpawnBirds();
                yield return new WaitForSeconds(1);
            }
        }

        private void SpawnBirds()
        {
            Vector3[] cells = _wayMatrix.GetRowWithIndex(0);
            foreach (var cell in cells)
            {
                if (UnityEngine.Random.Range(0, 100) > AggressiveBirdDensity) continue;
                GetPool<AggressiveBird>().Get(cell + new Vector3(0, 0, 100));
            }
        }

        private void SpawnBirdsMultiplieRows(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                Vector3[] cells = _wayMatrix.GetRowWithIndex(row);
                foreach (var cell in cells)
                {
                    if (UnityEngine.Random.Range(0, 100) > AggressiveBirdDensity) continue;
                    GetPool<AggressiveBird>().Get(cell + new Vector3(0, 0, 100));
                }
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}
