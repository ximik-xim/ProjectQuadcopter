using UnityEngine;

namespace Assets.Scripts
{
    public class Net : Reactable, ICollisionReactable, IRadiusReactable
    {
        public override void Construct()
        {
            throw new System.NotImplementedException();
        }

        public void OnTriggerEnter(Collider other) => TryGetReaction<KnockedDownReaction>().React();

        public void OnRadiusEnter(Quadcopter target) => TryGetReaction<LeanOutWindowReaction>().React();
    }
}