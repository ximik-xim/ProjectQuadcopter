using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public struct Pool<T> where T : MonoBehaviour
    {
        private List<T> _elements;
        private Transform _container;
        private T _elementPrefab;

        public void Fill(T element, Transform container, int amount)
        {
            _elementPrefab = element;
            _container = container;
            _elements = new List<T>();

            for (int i = 0; i < amount; i++)
                CreateElement();
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

            throw new Exception("No available elements!");
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

            availableElement = CreateElement(true);
            return false;
        }

        private T CreateElement(bool isActive = false)
        {
            T instance = UnityEngine.Object.Instantiate(_elementPrefab, _container);
            instance.gameObject.SetActive(isActive);
            _elements.Add(instance);
            return instance;
        }
    }
}
