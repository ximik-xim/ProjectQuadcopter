using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : EntityFactory<Clothesline>
    {
        public ClotheslineFactory(Clothesline prefab, Quadcopter quadcopter) : base(prefab, quadcopter) { }

        public override Clothesline GetCreated()
        {
            Clothesline clothesline = Object.Instantiate(_prefab);
            clothesline.gameObject.AddComponent<Mover>();
            clothesline.gameObject.AddComponent<Disappearer>();
            clothesline.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            return clothesline;
        }
    }
}
