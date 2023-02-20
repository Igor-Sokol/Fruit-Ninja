using DependencyInjection;
using Factories.Contracts.Generic;
using SceneChangeSystem;
using UnityEngine;

namespace Factories.Implementations
{
    public class SceneChangerFactory : IFactory<SceneChanger>
    {
        private SceneChanger _prefab;
        
        public SceneChanger Create()
        {
            _prefab ??= ProjectContext.Instance.GetServicePrefab<SceneChanger>();

            return Object.Instantiate(_prefab);
        }
    }
}