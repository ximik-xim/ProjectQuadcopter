using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : ActorFactory<AggressiveBird, AggressiveBirdConfig>
    {
        private Entity _target;

        public AggressiveBirdFactory(AggressiveBirdConfig config, Entity target) : base(config) => _target = target;

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_config.Prefab);
            aggressiveBird.gameObject.AddComponent<Mover>().SetSelfSpeed(_config.MoveSpeed);
            aggressiveBird.gameObject.AddComponent<Disappearer>();
            aggressiveBird.AddReaction<CollisionDetector>(new CausingDamage(_target.GetComponent<Health>()));
            aggressiveBird.AddReaction<FrontDetector>(new CryReaction()).SetRange(_config.VisibilDetector);
            return aggressiveBird;
        }
    }
}
