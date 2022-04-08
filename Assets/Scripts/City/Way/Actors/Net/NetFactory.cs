using UnityEngine;

namespace Assets.Scripts
{
    class NetFactory : ActorFactory<Net>
    {
        public NetFactory(Net prefab, Container container) : base(prefab, container) { }

        public override Net GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
