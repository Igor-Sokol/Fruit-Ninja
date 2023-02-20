using System;
using System.Collections.Generic;
using DependencyInjection.Contracts;
using Factories.Contracts.Generic;
using UnityEngine;

namespace DependencyInjection
{
    public class ProjectContext : MonoBehaviour
    {
        private static ProjectContext _instance;
        public static ProjectContext Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType<ProjectContext>();

                    if (!_instance)
                    {
                        var context = Resources.Load<ProjectContext>("ProjectContext/ProjectContext");
                        context.name = typeof(ProjectContext).ToString() + " (Singleton)";
                        DontDestroyOnLoad(context);
                        _instance = context;
                        
                        context.Init();
                    }
                }

                return _instance;
            }
        }

        private Dictionary<Type, object> _services;
        private Dictionary<Type, object> _servicesPrefabs;

        [SerializeField] private ServicePrefabInstaller[] servicePrefabInstallers;
        [SerializeField] private ServiceInstaller[] serviceInstallers;
        
        private void Init()
        {
            _services = new Dictionary<Type, object>();
            _servicesPrefabs = new Dictionary<Type, object>();

            foreach (var servicePrefabInstaller in servicePrefabInstallers)
            {
                servicePrefabInstaller.InstallService();
            }

            foreach (var serviceInstaller in serviceInstallers)
            {
                serviceInstaller.InstallService();
            }
        }

        public T GetService<T>()
        {
            if (_services.ContainsKey(typeof(T)))
            {
                return (T)_services[typeof(T)];
            }
            else if (_services.ContainsKey(typeof(IFactory<T>)))
            {
                IFactory<T> factory = (IFactory<T>)_services[typeof(IFactory<T>)];
                var instance = factory.Create();
                
                SetService<T, T>(instance);

                return instance;
            }

            return default;
        }

        public void SetService<T, TImplementation>(TImplementation service)
        {
            if (_services.ContainsKey(typeof(T)))
            {
                _services[typeof(T)] = service;
            }
            else
            {
                _services.Add(typeof(T), service);
            }
        }
        
        public T GetServicePrefab<T>()
        {
            if (_servicesPrefabs.ContainsKey(typeof(T)))
            {
                return (T)_servicesPrefabs[typeof(T)];
            }

            return default;
        }
        
        public void SetServicePrefab<T, TPrefab>(TPrefab service)
        {
            if (_servicesPrefabs.ContainsKey(typeof(T)))
            {
                _servicesPrefabs[typeof(T)] = service;
            }
            else
            {
                _servicesPrefabs.Add(typeof(T), service);
            }
        }
    }
}
