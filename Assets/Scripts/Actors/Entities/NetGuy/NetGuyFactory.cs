using UnityEngine;

namespace Assets.Scripts
{
    class NetGuyFactory : ActorFactory<NetGuy, NetGuyConfig>
    {
        private Quadcopter _quadcopter;

        public NetGuyFactory(NetGuyConfig config, Quadcopter quadcopter) : base(config) => _quadcopter = quadcopter;

        public override NetGuy GetCreated()
        {
            NetGuy netGuy = Object.Instantiate(_config.Prefab);
            WindowLeanOuter windowLeanOuter = netGuy.gameObject.AddComponent<WindowLeanOuter>();
            RadiusableDetector radiusDetector = netGuy.AddReaction<RadiusableDetector>(new LeanOutWindowReaction(windowLeanOuter,_config.SpeedDeparture));
            netGuy.gameObject.AddComponent<Mover>();
            netGuy.gameObject.AddComponent<Disappearer>().SetDisappearPoint(_quadcopter.transform.position + Vector3.back);
            netGuy.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            radiusDetector.SetRadius(_config.RangeDetector);
            radiusDetector.SetTarget(_quadcopter);
            return netGuy;
        }
    }
}
