using UnityEngine;

namespace Assets.Scripts
{
    public class Car : Reactable, ICollisionReactable
    {
        protected override void KnockOff() => base.KnockOff();

        public void OnCollisionEnter(Collision collision) => KnockOff();
    }
}