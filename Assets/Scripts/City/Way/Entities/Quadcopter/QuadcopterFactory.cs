using UnityEngine;

namespace Assets.Scripts
{
    class QuadcopterFactory : EntityFactory<Quadcopter>
    {
        public QuadcopterFactory(Quadcopter prefab, Container container) : base(prefab, container) { }

        public override Quadcopter GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
