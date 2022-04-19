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
            RadiusableDetector radiusableDetector = net.GetComponent<RadiusableDetector>();
            net.AddReaction(new LeanOutWindowReaction());
            net.AddReaction(new KnockedDownReaction(_quadcopter));
            radiusableDetector.SetTarget(_quadcopter);
            radiusableDetector.OnRadiusEnter += net.OnRadiusEnter;
            return net;
        }
    }
}
