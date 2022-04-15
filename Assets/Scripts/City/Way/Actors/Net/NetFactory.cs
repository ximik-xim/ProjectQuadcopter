using UnityEngine;

namespace Assets.Scripts
{
    class NetFactory : ActorFactory<Net>
    {
        Quadcopter _quadcopter;

        public NetFactory(Net prefab, Container container, Quadcopter quadcopter) : base(prefab, container) 
        {
            _quadcopter = quadcopter;
        }

        public override Net GetCreated()
        {
            Net net = Object.Instantiate(_prefab, _container.transform);
            net.AddReaction(new LeanOutWindowReaction());
            net.AddReaction(new KnockedDownReaction(_quadcopter));
            return net;
        }
    }
}
