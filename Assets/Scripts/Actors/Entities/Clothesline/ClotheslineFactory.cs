using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : MultiplePrefabActorFactory<Clothesline>
    {
        private Quadcopter _quadcopter;

        public ClotheslineFactory(IEnumerable<Clothesline>prefabs, Quadcopter quadcopter) : base(prefabs) => _quadcopter = quadcopter;

        public override Clothesline GetCreated()
        {
            Clothesline clothesline = Object.Instantiate(GetPrefab());
            clothesline.gameObject.AddComponent<Mover>();
            clothesline.gameObject.AddComponent<Disappearer>();
            clothesline.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            return clothesline;
        }
    }
}
