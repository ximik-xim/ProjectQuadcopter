using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [Header("Configurations")]
        [SerializeField] private City _city;
        [SerializeField] private WayMatrix _wayMatrix;
        [SerializeField][Range(10, 100)] private float _startSpeed;

        private EntitySpawner _entitySpawner;
        private ChunkGenerator _chunkGenerator;

        private void Awake()
        {
            _entitySpawner = GetComponentInChildren<EntitySpawner>();
            _chunkGenerator = GetComponentInChildren<ChunkGenerator>();
        }

        private void Start()
        {
            _wayMatrix.Generate();
            _entitySpawner.Init(_city, _wayMatrix);
            _chunkGenerator.Init(_city, _wayMatrix, _entitySpawner);
            SpeedService.SetStartSpeed(_startSpeed);
        }
    }
}