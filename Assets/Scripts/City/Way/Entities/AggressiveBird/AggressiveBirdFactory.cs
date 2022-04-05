using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : EntityFactory<AggressiveBird>
    {
        public AggressiveBirdFactory(AggressiveBird prefab, Container container) : base(prefab, container) { }

        public override AggressiveBird GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
