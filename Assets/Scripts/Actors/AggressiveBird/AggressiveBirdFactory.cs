using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : IFactory<AggressiveBird>
    {
        public AggressiveBird GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
