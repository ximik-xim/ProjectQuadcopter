using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : IFactory<Clothesline, Transform, Vector3, Clothesline>
    {
        public Clothesline Create(Clothesline prefab, Transform parent, Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}
