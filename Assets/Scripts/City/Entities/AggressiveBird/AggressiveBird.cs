using UnityEngine;

namespace Assets.Scripts
{
    public class AggressiveBird : Reactable, ICollisionReactable
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Quadcopter quadcopter))
                TryGetReaction<KnockedDownReaction>().React();
        }
    }
}