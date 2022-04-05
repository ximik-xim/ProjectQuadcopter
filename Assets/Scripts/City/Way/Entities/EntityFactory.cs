using UnityEngine;

namespace Assets.Scripts
{
    abstract class EntityFactory<E> : IFactory<E> where E : Entity
    {
        protected E _prefab;
        protected Container _container;

        public EntityFactory(E prefab, Container container)
        {
            _prefab = prefab;
            _container = container;
        }

        public abstract E GetCreated();
    }
}
