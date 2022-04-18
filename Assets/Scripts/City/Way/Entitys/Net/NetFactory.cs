using UnityEngine;

namespace Assets.Scripts
{
    class NetFactory : EntityFactory<Net>
    {
        Quadcopter _quadcopter;

        public NetFactory(Net prefab, Quadcopter quadcopter) : base(prefab) 
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
