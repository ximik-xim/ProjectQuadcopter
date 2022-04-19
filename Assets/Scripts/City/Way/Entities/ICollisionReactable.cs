using UnityEngine;

namespace Assets.Scripts
{
    public interface ICollisionReactable
    {
        public void OnTriggerEnter(Collider other);
    }
}
