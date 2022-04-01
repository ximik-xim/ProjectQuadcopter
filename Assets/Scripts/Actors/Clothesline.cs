using UnityEngine;

namespace Assets.Scripts
{
    public class Clothesline : ReactableEntity, ICollisionReactable
    {
        protected override void KnockOff() => base.KnockOff();

        public void OnCollisionEnter(Collision collision) => KnockOff();
    }
}