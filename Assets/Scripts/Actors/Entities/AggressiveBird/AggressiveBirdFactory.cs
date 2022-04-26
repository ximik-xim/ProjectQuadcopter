using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : EntityFactory<AggressiveBird>
    {
        Quadcopter _quadcopter;

        public AggressiveBirdFactory(AggressiveBird prefab, Quadcopter quadcopter) : base(prefab) 
        {
            _quadcopter = quadcopter;
        }

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_prefab);
            aggressiveBird.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            return aggressiveBird;
        }
    }
}
