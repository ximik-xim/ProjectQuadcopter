using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : MultiplePrefabActorFactory<AggressiveBird>
    {
        private Quadcopter _quadcopter;

        public AggressiveBirdFactory(IEnumerable<AggressiveBird> prefabs, Quadcopter quadcopter) : base(prefabs) => _quadcopter = quadcopter;

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(GetPrefab());
            aggressiveBird.gameObject.AddComponent<Mover>().SetSelfSpeed(5);
            aggressiveBird.gameObject.AddComponent<Disappearer>();
            aggressiveBird.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            return aggressiveBird;
        }
    }
}
