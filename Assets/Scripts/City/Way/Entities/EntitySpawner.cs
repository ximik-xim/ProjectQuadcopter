using System;
using System.Collections.Generic;
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
        public Pool<AggressiveBird> AggressiveBirdPool { get; private set; }
        public Pool<Car> CarPool { get; private set; }
        public Pool<Clothesline> ClotheslinePool { get; private set; }
        public Pool<Net> NetPool { get; private set; }

        public void Init(City city, WayMatrix wayMatrix)
        {
            EntitieContainer = ContainerService.GetCreatedContainer("Entities", city.transform, Vector3.zero);
            Quadcopter quadcopter = GetCreatedEntity(new QuadcopterFactory(_quadcopterPrefab, EntitieContainer, wayMatrix));
            GetCreatedEntity(new PlayerCameraFactory(_playerCameraPrefab, EntitieContainer, wayMatrix.Center));
            //AggressiveBirdPool = new Pool<AggressiveBird>(new AggressiveBirdFactory(_aggressiveBurdPrefab, quadcopter), EntitieContainer, 10);
            //CarPool = new Pool<Car>(new CarFactory(_carPrefab), EntitieContainer, 10);
            //ClotheslinePool = new Pool<Clothesline>(new ClotheslineFactory(_clotheslinePrefab), EntitieContainer, 10);
            NetPool = new Pool<Net>(new NetFactory(_netPrefab, quadcopter), EntitieContainer, 10); // его надо
        }

        private E GetCreatedEntity<E>(EntityFactory<E> entityFactory) where E : Entity => entityFactory.GetCreated();
    }
}
