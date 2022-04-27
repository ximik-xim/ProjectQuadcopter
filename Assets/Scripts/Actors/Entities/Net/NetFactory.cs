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
            net.AddReaction<RadiusableDetector>(new LeanOutWindowReaction());
            return net;
        }
    }
}
