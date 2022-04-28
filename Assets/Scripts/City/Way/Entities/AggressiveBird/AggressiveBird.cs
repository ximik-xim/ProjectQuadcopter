using UnityEngine;

namespace Assets.Scripts
{
    public class AggressiveBird : Reactable, ICollisionReactable,ILookReactable
    {
        public void TriggerEnter() => TryGetReaction<CausingDamage>().React();
        public void LookEnter() => TryGetReaction<LookObstaclesReaction>().React();

    }
}