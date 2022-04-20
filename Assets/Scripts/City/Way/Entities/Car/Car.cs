using UnityEngine;

namespace Assets.Scripts
{
    public class Car : Reactable, ICollisionReactable
    {
        public void OnTriggerEnter(Collider other) => TryGetReaction<KnockedDownReaction>().React();
    }
}