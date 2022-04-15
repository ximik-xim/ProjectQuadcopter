using UnityEngine;

namespace Assets.Scripts
{
    class QuadcopterFactory : ActorFactory<Quadcopter>
    {
        private WayMatrix _wayMatrix;

        public QuadcopterFactory(Quadcopter prefab, Container container, WayMatrix wayMatrix) : base(prefab, container) => _wayMatrix = wayMatrix;

        public override Quadcopter GetCreated()
        {
            Quadcopter quadcopter = Object.Instantiate(_prefab, _wayMatrix.Center, Quaternion.identity, _container.transform);
            quadcopter.GetComponent<SwipeController>().SetMatrix(_wayMatrix);
            return quadcopter;
        }
    }
}
