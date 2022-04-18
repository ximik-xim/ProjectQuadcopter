using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : EntityFactory<Car>
    {
        public CarFactory(Car prefab) : base(prefab) { }

        public override Car GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
