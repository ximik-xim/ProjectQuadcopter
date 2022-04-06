using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private Transform _city;
        [SerializeField] private SpeedProvider _speedProvider;
        [SerializeField] private WayGenerator _wayGenerator;

        [Header("Prefabs")]
        [SerializeField] private Quadcopter _quadcopterPrefab;
        [SerializeField] private PlayerCamera _playerCameraPrefab;
        [SerializeField] private AggressiveBird _aggressiveBurdPrefab;
        [SerializeField] private Car _carPrefab;
        [SerializeField] private Clothesline _clotheslinePrefab;
        [SerializeField] private Net _netPrefab;
        [SerializeField] private List<Chunk> _chunkPrefabs;

        [Header("Configurations")]
        [SerializeField] [Range(.1f, 10)] private float _startSpeed;

        private WayMatrix _wayMatrix = new WayMatrix();

        private Container _chunksContainer;
        private Container _entitieContainer;

        private PlayerCameraFactory _playerCameraFactory;
        private QuadcopterFactory _quadcopterFactory;

        private void Start()
        {
            _chunksContainer = GetCreatedContainer("ChunksContainer");
            _entitieContainer = GetCreatedContainer("EntityContainer");
            _speedProvider.SetStartSpeed(_startSpeed);
            _wayGenerator.GenerateChunks(_chunkPrefabs, _chunksContainer, _chunkPrefabs.Count); // Õ¿–”ÿ≈Õ¿ »Õ ¿œ—”Àﬂ÷»ﬂ CHUNK PREFABS !!!
            GetSpawnedPlayerCamera(_playerCameraPrefab);
            GetSpawnedQuadcopter(_quadcopterPrefab);
            _wayGenerator.StartLoop();
        }

        private Container GetCreatedContainer(string title)
        {
            GameObject container = new GameObject(title);
            container.transform.SetParent(_city);

            container.transform.position = new Vector3
            (
                _wayMatrix.GetPosition(MatrixPosition.Center).x,
                _wayMatrix.GetPosition(MatrixPosition.Center).y,
                _wayMatrix.Horizon
            );

            container.AddComponent(typeof(Container));
            return container.GetComponent<Container>();
        }

        private PlayerCamera GetSpawnedPlayerCamera(PlayerCamera playerCameraPrefab)
        {
            _playerCameraFactory = new PlayerCameraFactory(playerCameraPrefab, _entitieContainer, _wayMatrix.GetPosition(MatrixPosition.Center));
            return _playerCameraFactory.GetCreated();
        }

        private Quadcopter GetSpawnedQuadcopter(Quadcopter prefab)
        {
            _quadcopterFactory = new QuadcopterFactory(prefab, _entitieContainer, _wayMatrix.GetPosition(MatrixPosition.Center));
            return _quadcopterFactory.GetCreated();
        }
    }
}