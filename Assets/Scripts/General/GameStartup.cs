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
        [Space(30)]
        [SerializeField] private List<Chunk> _chunkPrefabs;

        [Header("Configurations")]
        [SerializeField] [Range(.1f, 10)] private float _startSpeed;

        private WayMatrix _wayMatrix = new WayMatrix();

        private Container _chunksContainer;
        private Container _entitieContainer;

        private void Start()
        {
            _chunksContainer = GetCreatedContainer("ChunksContainer");
            _entitieContainer = GetCreatedContainer("EntityContainer");
            _speedProvider.SetStartSpeed(_startSpeed);
            _wayGenerator.InitWay(_chunkPrefabs, _chunksContainer, _chunkPrefabs.Count); // Õ¿–”ÿ≈Õ¿ »Õ ¿œ—”Àﬂ÷»ﬂ CHUNK PREFABS !!!
            _wayGenerator.SpawnStartableChunks(5);
            GetCreatedActor(new PlayerCameraFactory(_playerCameraPrefab, _entitieContainer, _wayMatrix.GetPosition(MatrixPosition.Center)));
            GetCreatedActor(new QuadcopterFactory(_quadcopterPrefab, _entitieContainer, _wayMatrix.GetPosition(MatrixPosition.Center)));
        }

        private Container GetCreatedContainer(string title)
        {
            GameObject container = new GameObject(title);
            container.transform.SetParent(_city);
            container.transform.position = _wayMatrix.Horizon;
            container.AddComponent(typeof(Container));
            return container.GetComponent<Container>();
        }

        private T GetCreatedActor<T>(IFactory<T> factory) where T : Actor => factory.GetCreated();
    }
}