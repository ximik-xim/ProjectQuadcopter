using UnityEngine;

namespace Assets.Scripts
{
    public class ActorCreator
    {
        public T GetCreatedEntity<T>(IFactory<T> factory) where T : Actor => factory.GetCreated();
    }
}
