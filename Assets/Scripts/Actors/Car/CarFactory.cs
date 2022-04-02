using UnityEngine;

namespace Assets.Scripts
{
    public struct CarFactory : IFactory<Car, Transform, Vector3, Car>
    {
        public Car Create(Car prefab, Transform parent, Vector3 position)
        {
            return Object.Instantiate(prefab, position, Quaternion.identity, parent);
        }
    }
}
