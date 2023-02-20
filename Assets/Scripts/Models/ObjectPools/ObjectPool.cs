using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Models.ObjectPools
{
    [Serializable]
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly Stack<T> _objects = new Stack<T>();
    
        [SerializeField] private T prefab;
        [SerializeField] private Transform container;

        public void Init(T prefab, Transform container, int startCount = 0)
        {
            if (!this.container)
            {
                this.container = container;
            }
        
            if (!this.prefab)
            {
                this.prefab = prefab;

                for (int i = 0; i < startCount; i++)
                {
                    _objects.Push(CreateObject());
                }
            }
        }
        
        public T Get()
        {
            if (_objects.Count > 0)
            {
                var obj = _objects.Pop();
                obj.gameObject.SetActive(true);
                return obj;
            }

            return CreateObject();
        }

        public void Return(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(container);
            _objects.Push(obj);
        }
        
        private T CreateObject()
        {
            if (prefab)
            {
                return Object.Instantiate(prefab, container);
            }

            return null;
        }
    }
}