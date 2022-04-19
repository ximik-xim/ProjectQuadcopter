using UnityEngine;

namespace Assets.Scripts
{
    public class Net : Reactable, ICollisionReactable, IRadiusReactable
    {
        public void OnTriggerEnter(Collider other) => TryGetReaction<KnockedDownReaction>().React();

        public void OnRadiusEnter() => TryGetReaction<LeanOutWindowReaction>().React();
    }
}