using UnityEngine;

namespace Assets.Scripts
{
    public class Car : Reactable, ICollisionReactable,ILookReactable
    {
        public void TriggerEnter() => TryGetReaction<KnockedDownReaction>().React();
        public void LookEnter() => TryGetReaction<LookObstaclesReaction>().React();
    }
}