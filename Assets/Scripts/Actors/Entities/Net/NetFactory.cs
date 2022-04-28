using UnityEngine;

namespace Assets.Scripts
{
    class NetFactory : ActorFactory<Net, NetConfig>
    {
        private Quadcopter _quadcopter;

        public NetFactory(NetConfig config, Quadcopter quadcopter) : base(config) => _quadcopter = quadcopter;

        public override Net GetCreated()
        {
            Net net = Object.Instantiate(_config.Prefab);
            net.gameObject.AddComponent<Mover>();
            net.gameObject.AddComponent<Disappearer>();
            net.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            RadiusableDetector radiusDetector = net.AddReaction<RadiusableDetector>(new LeanOutWindowReaction());
            radiusDetector.SetRadius(25); // будем брать радиус из конфига
            radiusDetector.SetTarget(_quadcopter);
            return net;
        }
    }
}
