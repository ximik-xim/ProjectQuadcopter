using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : ActorFactory<Car, CarConfig>
    {
        private Entity target;

        public CarFactory(CarConfig config, Quadcopter target) : base(config) => this.target = target;

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_config.Prefab);
            car.gameObject.AddComponent<Mover>().SetSelfSpeed(_config.MoveSpeed);
            car.gameObject.AddComponent<Disappearer>();
            car.AddReaction<CollisionDetector>(new CausingDamage(target.GetComponent<Health>()));
            car.AddReaction<FrontDetector>(new CryReaction()).SetRange(_config.VisibilDetector);
            return car;
        }
    }
}
