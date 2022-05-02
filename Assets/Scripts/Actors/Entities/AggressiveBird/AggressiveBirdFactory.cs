using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : ActorFactory<AggressiveBird, AggressiveBirdConfig>
    {
        private Quadcopter _quadcopter;

        public AggressiveBirdFactory(AggressiveBirdConfig config, Quadcopter quadcopter) : base(config) => _quadcopter = quadcopter;

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(GuyConfig.Prefab);
            aggressiveBird.gameObject.AddComponent<Mover>().SetSelfSpeed(GuyConfig.MoveSpeed);
            aggressiveBird.gameObject.AddComponent<Disappearer>();
            aggressiveBird.AddReaction<CollisionDetector>(new CausingDamage(_quadcopter));
            aggressiveBird.AddReaction<VisibilityRangeDetector>(new LookObstaclesReaction()).SetRange(GuyConfig.VisibilDetector);
            return aggressiveBird;
        }
    }
}
