using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public struct Pool<T> where T : MonoBehaviour
    {
        private IFactory<T> _factory;
        private List<T> _elements;
        private Container _container;

        public void Init(IFactory<T> factory, Container container, int amount)
        {
            _factory = factory;
            _container = container;
            _elements = new List<T>();

            for (int i = 0; i < amount; i++)
            {
                Create(false);
            }
        }

        public T Get()
        {
            if (HasAvailable(out T availableElement))
                return availableElement;

            return Create(true);
        }

        public void Return(T element) => PoolUp(element, false);

        private void PoolUp(T element, bool isActive)
        {
            element.transform.SetParent(_container.transform);
            element.transform.localPosition = Vector3.zero;
            element.gameObject.SetActive(isActive);
        }

        private bool HasAvailable(out T availableElement)
        {
            foreach (T element in _elements)
            {
                if (element.gameObject.activeSelf == false)
                {
                    element.transform.SetParent(null);
                    element.gameObject.SetActive(true);
                    availableElement = element;
                    return true;
                }
            }

            availableElement = null;
            return false;
        }

        private T Create(bool isActive)
        {
            T element = _factory.GetCreated();
            _elements.Add(element);
            PoolUp(element, isActive);
            return element;
        }
    }
}
