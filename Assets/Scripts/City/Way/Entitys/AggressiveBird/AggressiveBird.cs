using UnityEngine;

namespace Assets.Scripts
{
    public class AggressiveBird : Reactable, ICollisionReactable
    {
        public override void Construct()
        {
            throw new System.NotImplementedException();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Quadcopter quadcopter))
                TryGetReaction<KnockedDownReaction>().React();
        }
    }
}