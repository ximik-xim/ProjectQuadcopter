using UnityEngine;

namespace Assets.Scripts
{
    public class Clothesline : Reactable, ICollisionReactable
    {
        public void OnTriggerEnter(Collider other) => TryGetReaction<KnockedDownReaction>().React();
    }
}