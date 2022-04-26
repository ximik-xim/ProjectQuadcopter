using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ActorFactory<A> : IFactory<A> where A : Actor
    {
        protected A _prefab;
        protected Container _container;
        protected Vector3 _spawnPosition;

        public ActorFactory(A prefab) => _prefab = prefab;

        public ActorFactory(A prefab, Container container)
        {
            _prefab = prefab;
            _container = container;
        }

        public ActorFactory(A prefab, Container container, Vector3 spawnPosition)
        {
            _prefab = prefab;
            _container = container;
            _spawnPosition = spawnPosition;
        }

        public abstract A GetCreated();
    }
}
