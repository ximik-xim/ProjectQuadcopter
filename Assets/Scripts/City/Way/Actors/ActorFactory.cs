using UnityEngine;

namespace Assets.Scripts
{
    abstract class ActorFactory<E> : IFactory<E> where E : Actor
    {
        protected E _prefab;
        protected Container _container;

        public ActorFactory(E prefab, Container container)
        {
            _prefab = prefab;
            _container = container;
        }

        public abstract E GetCreated();
    }
}
