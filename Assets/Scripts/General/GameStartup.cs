using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private Transform _city;
        [SerializeField] private Way _way;

        [Header("Prefabs")]
        [SerializeField] private Quadcopter _quadcopterPrefab;
        [SerializeField] private PlayerCamera _playerCameraPrefab;
        [SerializeField] private AggressiveBird _aggressiveBurdPrefab;
        [SerializeField] private Car _carPrefab;
        [SerializeField] private Clothesline _clotheslinePrefab;
        [SerializeField] private Net _netPrefab;
        [SerializeField] private List<Chunk> _chunkPrefabs;


        private void Start()
        {
            _way.Init();
            _way.SpawnChunks(_chunkPrefabs, 10);
            _way.SpawnPlayerCamera(_playerCameraPrefab);
        }
    }
}