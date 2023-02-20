using GameSystems.SceneChangeSystem;
using Models.DependencyInjection;
using Models.Factories.Contracts.Generic;
using UnityEngine;

namespace Models.Factories.Implementations
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