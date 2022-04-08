using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : ActorFactory<Car>
    {
        public CarFactory(Car prefab, Container container) : base(prefab, container) { }

        public override Car GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
