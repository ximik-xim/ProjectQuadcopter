using UnityEngine;

namespace Assets.Scripts
{
    class QuadcopterFactory : ActorFactory<Quadcopter>
    {
        private WayMatrix _wayMatrix;

        public QuadcopterFactory(Quadcopter prefab, Container container, WayMatrix wayMatrix) : base(prefab, container)
        {
            _wayMatrix = wayMatrix;
        }


        public override Quadcopter GetCreated()
        {
            Quadcopter quadcopter = Object.Instantiate(_prefab, _container.transform);
            SwipeController swipeController = quadcopter.gameObject.AddComponent<SwipeController>();
            swipeController.SetMatrix(_wayMatrix);
            swipeController.SetStartPosition(1, 1);
            swipeController.SetMotionDuration(0.3f);
            quadcopter.transform.position = _wayMatrix.GetPosition(swipeController.CurrentPositionX, swipeController.CurrentPositionY);

            return quadcopter;
        }
    }
}
