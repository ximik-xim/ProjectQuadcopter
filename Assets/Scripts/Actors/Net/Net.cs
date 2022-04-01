using UnityEngine;

namespace Assets.Scripts
{
    public class Net : ReactableEntity, IRadiusReactable, ICollisionReactable
    {
        protected override void Catch() => base.Catch();

        protected override void LeanOutTheWindow() => base.LeanOutTheWindow();

        public void OnCollisionEnter(Collision collision) => Catch();

        public void OnRadiusEnter() => LeanOutTheWindow();
    }
}