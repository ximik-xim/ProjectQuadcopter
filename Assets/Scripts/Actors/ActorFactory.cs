using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ActorFactory<A, C> : IFactory<A> where A : Actor where C : Config
    {
        protected C GuyConfig;
        protected Container _container;
        protected Vector3 _spawnPosition;

        public ActorFactory(C guyConfig) => GuyConfig = guyConfig;

        public ActorFactory(C guyConfig, Container container)
        {
            GuyConfig = guyConfig;
            _container = container;
            _spawnPosition = container.transform.position;
        }

        public ActorFactory(C guyConfig, Container container, Vector3 spawnPosition)
        {
            GuyConfig = guyConfig;
            _container = container;
            _spawnPosition = spawnPosition;
        }

        public abstract A GetCreated();
    }
}
