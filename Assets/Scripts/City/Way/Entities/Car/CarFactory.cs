using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : EntityFactory<Car>
    {
        public CarFactory(Car prefab) : base(prefab) { }

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_prefab);
            CollisionDetector collisionDetector = car.gameObject.AddComponent<CollisionDetector>();
            VisibilityRangeDetector visibilityRangeDetector = car.GetComponent<VisibilityRangeDetector>();
            KnockedDownReaction knockedDownReaction = new KnockedDownReaction();
            
            car.AddReaction(new LookObstaclesReaction());
            car.AddReaction(knockedDownReaction);
            
            collisionDetector.Detecting += GetParametrs;
            collisionDetector.Detecting += delegate(GameObject o) { car.TriggerEnter(); };
            visibilityRangeDetector.Detecting += delegate(GameObject o) { car.LookEnter(); };
            
            return car;
            
            void GetParametrs(GameObject gameObject)
            {
                
                if (gameObject.TryGetComponent<Health>(out Health health))
                {
                    knockedDownReaction.SetParametrs(health);    
                    return;
                }
                
                Debug.Log("Ошибка, на компоненте нету ХП");
            }
            
        }
    }
}
