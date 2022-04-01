using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : IFactory<Car>
    {
        public Car GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
