using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : IFactory<AggressiveBird, Transform, Vector3, AggressiveBird>
    {
        public AggressiveBird Create(AggressiveBird prefab, Transform parent, Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}
