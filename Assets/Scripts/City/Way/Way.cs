using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Way : MonoBehaviour
    {
        private WayMatrix _matrix;
        private Container _chunksContainer;
        private Container _entitieContainer;
        private Coroutine _loopRoutine;
        

        private ChunkFactory _chunkFactory;
        private PlayerCameraFactory _playerCameraFactory;

        private Pool<Chunk> _chunksPool;
        private PlayerCamera _playerCamera;
        private Quadcopter _quadcopter;

        public void Init()
        {
            _matrix = new WayMatrix(30, 2);
            _chunksContainer = GetCreatedContainer("ChunksContainer");
            _entitieContainer = GetCreatedContainer("EntityContainer");
        }

        private void OnEnable()
        {

        }

        private Container GetCreatedContainer(string title)
        {
            GameObject container = new GameObject(title);
            container.transform.SetParent(transform);

            container.transform.position = new Vector3
            (
                _matrix.GetPosition(MatrixPosition.Center).x,
                _matrix.GetPosition(MatrixPosition.Center).y,
                _matrix.Horizon
            );

            container.AddComponent(typeof(Container));
            return container.GetComponent<Container>();
        }

        public void SpawnChunks(List<Chunk> chunkPrefabs, int amount)
        {
            _chunkFactory = new ChunkFactory(chunkPrefabs, _chunksContainer);

            for (int i = 0; i < chunkPrefabs.Count; i++)
            {
                _chunksPool.Init(_chunkFactory, _chunksContainer, amount);
            }
        }

        public void SpawnPlayerCamera(PlayerCamera playerCameraPrefab)
        {
            _playerCameraFactory = new PlayerCameraFactory(playerCameraPrefab, _entitieContainer, _matrix.GetPosition(MatrixPosition.Center));
            _playerCamera = _playerCameraFactory.GetCreated();
        }

        private void OnDisable()
        {

        }
    }
}