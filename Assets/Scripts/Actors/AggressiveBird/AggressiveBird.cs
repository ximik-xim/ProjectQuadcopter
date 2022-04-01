using UnityEngine;

namespace Assets.Scripts
{
    public class AggressiveBird : ReactableEntity, ICollisionReactable
    {
        protected override void TakeHalfHP() => base.TakeHalfHP();

        public void OnCollisionEnter(Collision collision) => base.TakeHalfHP();
    }
}