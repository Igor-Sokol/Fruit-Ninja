using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class ObjectPool<T> where T : MonoBehaviour
{
    private readonly Dictionary<T, bool> _objects = new Dictionary<T, bool>();
    
    [SerializeField] private T prefab;
    [SerializeField] private Transform container;

    public void Init(T prefab, Transform container, int startCount = 0)
    {
        if (!container)
        {
            this.container = container;
        }
        
        if (!this.prefab)
        {
            this.prefab = prefab;

            for (int i = 0; i < startCount; i++)
            {
                _objects.Add(CreateObject(), false);
            }
        }
    }
        
    public T Get()
    {
        var obj = _objects.FirstOrDefault(o => o.Value == false);
            
        if (obj.Key == null)
        {
            var newObject = CreateObject();
            _objects.Add(newObject, true);
            return newObject;
        }
        else
        {
            _objects[obj.Key] = true;
            obj.Key.gameObject.SetActive(true);
            return obj.Key;
        }
    }

    public bool Return(T obj)
    {
        if (_objects.ContainsKey(obj))
        {
            _objects[obj] = false;
            obj.gameObject.SetActive(false);
            
            return true;
        }

        return false;
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