using UnityEngine;

namespace Assets.Scripts
{
    class QuadcopterFactory : ActorFactory<Quadcopter, QuadcopterConfig>
    {
        private WayMatrix _wayMatrix;

        public QuadcopterFactory(QuadcopterConfig config, Container container, WayMatrix wayMatrix) : base(config, container)
        {
            _wayMatrix = wayMatrix;
        }


        public override Quadcopter GetCreated()
        {
            Quadcopter quadcopter = Object.Instantiate(_config.Prefab, _container.transform);
            SwipeController swipeController = quadcopter.gameObject.AddComponent<SwipeController>();
            swipeController.SetMatrix(_wayMatrix);
            swipeController.SetStartPosition(1, 1);
            swipeController.SetMotionDuration(_config.MotionDuration);
            quadcopter.transform.position = _wayMatrix.GetPosition(swipeController.CurrentPositionX, swipeController.CurrentPositionY);

            return quadcopter;
        }
    }
}
