using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MultiplePrefabActorConfig<T> : Config where T : Actor
    {
        [SerializeField] protected List<T> _prefabs;

        public IEnumerable<T> Prefabs
        {
            get
            {
                T[] prefabs = new T[_prefabs.Count];
                _prefabs.CopyTo(prefabs);
                return prefabs;
            }
        }
    }
}
