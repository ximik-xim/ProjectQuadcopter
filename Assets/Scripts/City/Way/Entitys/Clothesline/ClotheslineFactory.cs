using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : EntityFactory<Clothesline>
    {
        public ClotheslineFactory(Clothesline prefab) : base(prefab) { }

        public override Clothesline GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
