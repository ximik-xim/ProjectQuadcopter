using UnityEngine;

namespace Assets.Scripts
{
    class NetGuyFactory : ActorFactory<NetGuy, NetGuyConfig>
    {
        private Quadcopter _quadcopter;

        public NetGuyFactory(NetGuyConfig guyConfig, Quadcopter quadcopter) : base(guyConfig) => _quadcopter = quadcopter;

        public override NetGuy GetCreated()
        {
            NetGuy netGuy = Object.Instantiate(GuyConfig.Prefab);
            netGuy.gameObject.AddComponent<Mover>().SetSelfSpeed(GuyConfig.MoveSpeed);
            netGuy.gameObject.AddComponent<Disappearer>();
            netGuy.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            RadiusableDetector radiusDetector = netGuy.AddReaction<RadiusableDetector>(new LeanOutWindowReaction());
            radiusDetector.SetRadius(GuyConfig.RangeDetector);
            radiusDetector.SetTarget(_quadcopter);
            return netGuy;
        }
    }
}
