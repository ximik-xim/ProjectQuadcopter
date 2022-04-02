using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public struct Pool<T> where T : MonoBehaviour
    {
        private List<T> _elements;
        private Transform _container;

        public void AddElement(T element)
        {
            _container = element.transform.parent;
            _elements = new List<T>();

            element.gameObject.SetActive(false);
            element.transform.SetParent(_container);
            element.transform.localPosition = Vector3.zero;
            _elements.Add(element);
        }

        public void Return(T element)
        {
            element.transform.SetParent(_container);
            element.transform.localPosition = Vector3.zero;
            element.gameObject.SetActive(false);
        }

        public T Get()
        {
            if (HasAvailable(out T element))
                return element;

            return null;
        }

        public bool HasAvailable(out T availableElement)
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

            throw new Exception("No available elements!");
        }
    }
}
