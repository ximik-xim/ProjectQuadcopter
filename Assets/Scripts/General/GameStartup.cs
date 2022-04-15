using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private City _city;
        [SerializeField] private WayMatrix _wayMatrix;
        [SerializeField] private ChunkGenerator _chunkGenerator;

        [Header("Prefabs")]
        [SerializeField] private Quadcopter _quadcopterPrefab;
        [SerializeField] private PlayerCamera _playerCameraPrefab;
        [SerializeField] private AggressiveBird _aggressiveBurdPrefab;
        [SerializeField] private Car _carPrefab;
        [SerializeField] private Clothesline _clotheslinePrefab;
        [SerializeField] private Net _netPrefab;
        [Space(30)]
        [SerializeField] private List<Chunk> _chunkPrefabs;

        [Header("Configurations")]
        [SerializeField] [Range(10, 100)] private float _startSpeed;

        
        private Container _entitieContainer;

        private void Start()
        {
            _wayMatrix.Generate();
            _entitieContainer = ContainerService.GetCreatedContainer("EntityContainer", _city.transform, Vector3.zero);
            SpeedService.SetStartSpeed(_startSpeed);
            GetCreatedActor(new QuadcopterFactory(_quadcopterPrefab, _entitieContainer, _wayMatrix));
            GetCreatedActor(new PlayerCameraFactory(_playerCameraPrefab, _entitieContainer, _wayMatrix.Center));
            _chunkGenerator.Init(_city, _wayMatrix, _chunkPrefabs, 5);
        }

        private T GetCreatedActor<T>(IFactory<T> factory) where T : Actor => factory.GetCreated();
    }
}