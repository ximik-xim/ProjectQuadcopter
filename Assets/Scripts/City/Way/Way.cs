using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Way : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 10)] private float _startSpeed;

        private Container _chunksContainer;
        private Container _entitieContainer;
        private Coroutine _loopRoutine;
        

        private ChunkFactory _chunkFactory;
        private PlayerCameraFactory _playerCameraFactory;
        private QuadcopterFactory _quadcopterFactory;

        private Pool<Chunk> _chunksPool;

        public static WayMatrix Matrix { get; private set; }
        public static float Speed { get; private set; }

        public void Init()
        {
            Matrix = new WayMatrix(50, 5);
            Speed = _startSpeed;
            _chunksContainer = GetCreatedContainer("ChunksContainer");
            _entitieContainer = GetCreatedContainer("EntityContainer");
        }

        public void GetPosition(MatrixPosition matrixPosition) => Matrix.GetPosition(matrixPosition);

        public void SpawnChunks(List<Chunk> chunkPrefabs, int amount)
        {
            _chunkFactory = new ChunkFactory(chunkPrefabs, _chunksContainer);
            _chunksPool.Init(_chunkFactory, _chunksContainer, amount);
        }

        public PlayerCamera GetSpawnedPlayerCamera(PlayerCamera playerCameraPrefab)
        {
            _playerCameraFactory = new PlayerCameraFactory(playerCameraPrefab, _entitieContainer, Matrix.GetPosition(MatrixPosition.Center));
            return _playerCameraFactory.GetCreated();
        }

        public Quadcopter GetSpawnedQuadcopter(Quadcopter prefab)
        {
            _quadcopterFactory = new QuadcopterFactory(prefab, _entitieContainer, Matrix.GetPosition(MatrixPosition.Center));
            return _quadcopterFactory.GetCreated();
        }

        public void StartLoop() => _loopRoutine = StartCoroutine(LoopRoutine());

        private IEnumerator LoopRoutine()
        {
            float spawnTemp = 1.5f;

            while (true)
            {
                _chunksPool.Get();
                yield return new WaitForSeconds(spawnTemp * Speed);
            }
        }

        private Container GetCreatedContainer(string title)
        {
            GameObject container = new GameObject(title);
            container.transform.SetParent(transform);

            container.transform.position = new Vector3
            (
                Matrix.GetPosition(MatrixPosition.Center).x,
                Matrix.GetPosition(MatrixPosition.Center).y,
                Matrix.Horizon
            );

            container.AddComponent(typeof(Container));
            return container.GetComponent<Container>();
        }

        private void OnDisable() => StopCoroutine(_loopRoutine);
    }
}