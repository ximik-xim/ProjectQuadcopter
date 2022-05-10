using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : ActorFactory<Clothesline, ClotheslineConfig>
    {
        private Entity _target;

        public ClotheslineFactory(ClotheslineConfig config, Entity target) : base(config) => _target = target;

        public override Clothesline GetCreated()
        {
            Clothesline clothesline = Object.Instantiate(_config.Prefab);
            clothesline.gameObject.AddComponent<Mover>();
            clothesline.gameObject.AddComponent<Disappearer>();
            clothesline.AddReaction<CollisionDetector>(new CausingDamage(_target.GetComponent<Health>()));
            return clothesline;
        }
    }
}
