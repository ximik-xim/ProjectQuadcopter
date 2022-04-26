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
            Net net = Object.Instantiate(_prefab);
            net.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            net.AddReaction<RadiusableDetector>(new LeanOutWindowReaction());
            return net;
        }
    }
}
