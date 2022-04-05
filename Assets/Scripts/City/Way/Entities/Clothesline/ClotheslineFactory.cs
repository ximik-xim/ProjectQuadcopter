using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : EntityFactory<Clothesline>
    {
        public ClotheslineFactory(Clothesline prefab, Container container) : base(prefab, container) { }

        public override Clothesline GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
