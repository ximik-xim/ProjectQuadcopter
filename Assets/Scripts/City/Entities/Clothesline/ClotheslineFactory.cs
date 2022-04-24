using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : EntityFactory<Clothesline>
    {
        private Quadcopter _quadcopter;

        public ClotheslineFactory(Clothesline prefab, Quadcopter quadcopter) : base(prefab) => _quadcopter = quadcopter;

        public override Clothesline GetCreated()
        {
            Clothesline clothesline = Object.Instantiate(_prefab);
            clothesline.AddReaction(new KnockedDownReaction(_quadcopter));
            return clothesline;
        }
    }
}
