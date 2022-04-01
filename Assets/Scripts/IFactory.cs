using UnityEngine;

namespace Assets.Scripts
{
    interface IFactory<T> where T : MonoBehaviour
    {
        public T GetCreated();
    }
}
