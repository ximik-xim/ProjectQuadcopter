using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : EntityFactory<Car>
    {
        public CarFactory(Car prefab, Quadcopter quadcopter) : base(prefab, quadcopter) { }

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_prefab);
            car.gameObject.AddComponent<Mover>().SetSelfSpeed(3);
            car.gameObject.AddComponent<Disappearer>();
            car.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            return car;
        }
    }
}
