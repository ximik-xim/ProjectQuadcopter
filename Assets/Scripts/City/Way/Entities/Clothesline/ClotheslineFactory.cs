using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : EntityFactory<Clothesline>
    {
        public ClotheslineFactory(Clothesline prefab) : base(prefab) { }

        public override Clothesline GetCreated()
        {
            Clothesline clothesline = Object.Instantiate(_prefab);
            CollisionDetector collisionDetector = clothesline.gameObject.AddComponent<CollisionDetector>();
            KnockedDownReaction knockedDownReaction = new KnockedDownReaction();
            
            clothesline.AddReaction(knockedDownReaction);
            
            collisionDetector.Detecting += GetParametrs;
            collisionDetector.Detecting += delegate(GameObject o) { clothesline.TriggerEnter(); };

            return clothesline;
            
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
