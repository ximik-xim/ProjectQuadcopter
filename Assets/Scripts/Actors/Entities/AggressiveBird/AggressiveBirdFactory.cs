using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : EntityFactory<AggressiveBird>
    {
        public AggressiveBirdFactory(AggressiveBird prefab, Quadcopter quadcopter) : base(prefab, quadcopter) { }

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_prefab);
            aggressiveBird.gameObject.AddComponent<Mover>().SetSelfSpeed(5);
            aggressiveBird.gameObject.AddComponent<Disappearer>();
            aggressiveBird.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            return aggressiveBird;
        }
    }
}
