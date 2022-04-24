using UnityEngine;

namespace Assets.Scripts
{
    class QuadcopterFactory : EntityFactory<Quadcopter>
    {
        private WayMatrix _wayMatrix;

        public QuadcopterFactory(Quadcopter prefab, Container container, WayMatrix wayMatrix) : base(prefab, container) => _wayMatrix = wayMatrix;

        public override Quadcopter GetCreated()
        {
            Quadcopter quadcopter = Object.Instantiate(_prefab, _container.transform);
            SwipeController swipeController = quadcopter.GetComponent<SwipeController>();
            swipeController.SetMatrix(_wayMatrix);
            swipeController.SetStartPosition(1, 1);

            quadcopter.transform.position = _wayMatrix
                .GetPosition(swipeController.CurrentPositionX, swipeController.CurrentPositionY);

            return quadcopter;
        }
    }
}
