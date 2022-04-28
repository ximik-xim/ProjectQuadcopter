using UnityEngine;

namespace Assets.Scripts
{
    class NetFactory : EntityFactory<Net>
    {
        Quadcopter _quadcopter;

        public NetFactory(Net prefab, Quadcopter quadcopter) : base(prefab) 
        {
            _quadcopter = quadcopter;
        }

        public override Net GetCreated()
        {
            Net net = Object.Instantiate(_prefab);
            RadiusableDetector radiusableDetector = net.GetComponent<RadiusableDetector>();
            CollisionDetector collisionDetector = net.GetComponent<CollisionDetector>();
            KnockedDownReaction knockedDownReaction = new KnockedDownReaction();
            
            net.AddReaction(new LeanOutWindowReaction());
            net.AddReaction(knockedDownReaction);
            
            //radiusableDetectorTarget.SetTarget(_quadcopter);
            
            collisionDetector.Detecting += GetParametrs;
            collisionDetector.Detecting += delegate(GameObject o) { net.TriggerEnter(); };
            radiusableDetector.Detecting += delegate(GameObject o) { net.RadiusEnter(); };
            

            return net;
            
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
