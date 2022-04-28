using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : EntityFactory<AggressiveBird>
    {
        Quadcopter _quadcopter;

        public AggressiveBirdFactory(AggressiveBird prefab, Quadcopter quadcopter) : base(prefab) 
        {
            _quadcopter = quadcopter;
        }

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_prefab); 
            CollisionDetector collisionDetector = aggressiveBird.GetComponent<CollisionDetector>();
            VisibilityRangeDetector visibilityRangeDetector = aggressiveBird.GetComponent<VisibilityRangeDetector>();
            CausingDamage causingDamage = new CausingDamage();

            aggressiveBird.AddReaction(new LookObstaclesReaction());
            aggressiveBird.AddReaction(causingDamage);

            collisionDetector.Detecting += GetParametrs;
            collisionDetector.Detecting += delegate(GameObject o) { aggressiveBird.TriggerEnter(); };
            visibilityRangeDetector.Detecting += delegate(GameObject o) { aggressiveBird.LookEnter(); };
            
            return aggressiveBird;

            void GetParametrs(GameObject gameObject)
            {

                if (gameObject.TryGetComponent<Health>(out Health health))
                {
                    causingDamage.SetParametrs(health);
                    return;
                }
            }
        }
    }
}
