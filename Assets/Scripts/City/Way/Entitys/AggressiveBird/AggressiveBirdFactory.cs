using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : EntityFactory<AggressiveBird>
    {
        Quadcopter _quadcopter;

        public AggressiveBirdFactory(AggressiveBird prefab, Container container, Quadcopter quadcopter) : base(prefab, container) 
        {
            _quadcopter = quadcopter;
        }

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_prefab, _container.transform);
            aggressiveBird.AddReaction(new KnockedDownReaction(_quadcopter));
            return aggressiveBird;
        }
    }
}
