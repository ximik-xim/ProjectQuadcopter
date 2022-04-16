using UnityEngine;

namespace Assets.Scripts
{
    public class Clothesline : Reactable, ICollisionReactable
    {
        public override void Construct()
        {
            throw new System.NotImplementedException();
        }

        public void OnTriggerEnter(Collider other) => TryGetReaction<KnockedDownReaction>().React();
    }
}