using System;
using System.Collections.Generic;
using Models.DependencyInjection.Contracts;
using UnityEngine;

namespace Models.DependencyInjection
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
                        var contextResource = Resources.Load<ProjectContext>("ProjectContext/ProjectContext");
                        ProjectContext context;
                        
                        if (contextResource is null)
                        {
                            var contextContainer = new GameObject();
                            context = contextContainer.AddComponent<ProjectContext>();
                        }
                        else
                        {
                            context = Instantiate(contextResource);
                        }
                        
                        context.name = typeof(ProjectContext).ToString() + " (Singleton)";
                        DontDestroyOnLoad(context.gameObject);
                        _instance = context;
                        
                        context.Init();
                    }
                }

                return _instance;
            }
        }

        private Dictionary<Type, object> _services;
        
        [SerializeField] private ServiceInstaller[] serviceInstallers;
        
        private void Init()
        {
            _services = new Dictionary<Type, object>();

            foreach (var serviceInstaller in serviceInstallers)
            {
                serviceInstaller.ProjectContext = this;
                serviceInstaller.InstallService();
            }
        }

        public T GetService<T>()
        {
            if (_services.TryGetValue(typeof(T), out object value))
            {
                return (T)value;
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
    }
}
