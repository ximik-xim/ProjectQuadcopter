using UnityEngine;

namespace Assets.Scripts
{
    public interface ICollisionReactable
    {
        public void OnCollisionEnter(Collision collision);
    }
}
