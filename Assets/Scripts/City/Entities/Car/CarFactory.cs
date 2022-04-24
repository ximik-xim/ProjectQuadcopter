using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : EntityFactory<Car>
    {
        private Quadcopter _quadcopter;

        public CarFactory(Car prefab, Quadcopter quadcopter) : base(prefab) => _quadcopter = quadcopter;

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_prefab);
            car.AddReaction(new KnockedDownReaction(_quadcopter));
            return car;
        }
    }
}
