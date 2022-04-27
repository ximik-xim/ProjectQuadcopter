using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class MultiplePrefabActorFactory<A> : IFactory<A> where A : Actor
    {
        private List<A> _prefabs = new List<A>();
        protected int _prefabIndex;
        protected Container _container;
        protected Vector3 _spawnPosition;

        public MultiplePrefabActorFactory(IEnumerable<A> prefabs) => _prefabs.AddRange(prefabs);

        public MultiplePrefabActorFactory(IEnumerable<A> prefabs, Container container)
        {
            _prefabs.AddRange(prefabs);
            _container = container;
            _spawnPosition = container.transform.position;
        }

        public MultiplePrefabActorFactory(IEnumerable<A> prefabs, Container container, Vector3 spawnPosition)
        {
            _prefabs.AddRange(prefabs);
            _container = container;
            _spawnPosition = spawnPosition;
        }

        public abstract A GetCreated();

        protected A GetPrefab()
        {
            _prefabIndex = (_prefabIndex == _prefabs.Count) ? 0 : _prefabIndex;
            A prefab = _prefabs[_prefabIndex];
            _prefabIndex++;
            return prefab;
        }
    }
}
