using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Entity : Actor
    {
        public IDetector AddReaction<D>(IReaction reaction) where D : Component
        {
            IDetector detector = gameObject.AddComponent<D>() as IDetector;
            detector.OnDetect += reaction.React;
            return detector;
        }
    }
}