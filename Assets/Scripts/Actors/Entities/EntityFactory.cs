using UnityEngine;

namespace Assets.Scripts
{
    public abstract class EntityFactory<E> : ActorFactory<E> where E : Entity
    {
        protected Quadcopter _quadcopter;

        public EntityFactory(E prefab, Quadcopter quadcopter) : base(prefab) { }

        public EntityFactory(E prefab, Container container, Quadcopter quadcopter) : base(prefab, container) { }

        public EntityFactory(E prefab, Container container, Vector3 spawnPosition, Quadcopter quadcopter) : base(prefab, container, spawnPosition) { }
    }
}
