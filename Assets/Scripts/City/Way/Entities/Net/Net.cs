using UnityEngine;

namespace Assets.Scripts
{
    public class Net : Reactable, ICollisionReactable, IRadiusReactable
    {
        public void TriggerEnter() => TryGetReaction<KnockedDownReaction>().React();

        public void RadiusEnter() => TryGetReaction<LeanOutWindowReaction>().React();
        
    }
}