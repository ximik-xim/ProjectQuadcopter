using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : MultiplePrefabActorFactory<Car>
    {
        private Quadcopter _quadcopter;

        public CarFactory(IEnumerable<Car> prefabs, Quadcopter quadcopter) : base(prefabs) => _quadcopter = quadcopter;

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(GetPrefab());
            car.gameObject.AddComponent<Mover>().SetSelfSpeed(3);
            car.gameObject.AddComponent<Disappearer>();
            car.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            return car;
        }
    }
}
