using UnityEngine;

namespace Assets.Scripts
{
    class NetFactory : IFactory<Net, Transform, Vector3, Net>
    {
        public Net Create(Net prefab, Transform parent, Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}
