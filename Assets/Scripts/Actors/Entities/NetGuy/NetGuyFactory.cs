using UnityEngine;

namespace Assets.Scripts
{
    class NetGuyFactory : ActorFactory<NetGuy, NetGuyConfig>
    {
        private Entity _target;

        public NetGuyFactory(NetGuyConfig config, Entity target) : base(config) => _target = target;

        public override NetGuy GetCreated()
        {
            NetGuy netGuy = Object.Instantiate(_config.Prefab);
            netGuy.gameObject.AddComponent<Mover>();
            netGuy.gameObject.AddComponent<Disappearer>().SetDisappearPoint(_target.transform.position + Vector3.back);
            WindowLeanOuter windowLeanOuter = netGuy.gameObject.AddComponent<WindowLeanOuter>();
            netGuy.AddReaction<CollisionDetector>(new CausingDamage(_target.GetComponent<Health>()));
            RadiusableDetector radiusDetector = netGuy.AddReaction<RadiusableDetector>(new LeanOutWindowReaction(windowLeanOuter));
            radiusDetector.SetRadius(_config.DetectionRange);
            radiusDetector.SetTarget(_target);
            return netGuy;
        }
    }
}
