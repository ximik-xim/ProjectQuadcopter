using UnityEngine;

namespace Assets.Scripts
{
    public class Clothesline : Reactable, ICollisionReactable
    {
        public void TriggerEnter() => TryGetReaction<KnockedDownReaction>().React();
    }
}