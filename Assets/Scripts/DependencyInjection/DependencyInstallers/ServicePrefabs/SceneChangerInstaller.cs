using DependencyInjection.Contracts;
using SceneChangeSystem;
using UnityEngine;

namespace DependencyInjection.DependencyInstallers.ServicePrefabs
{
    public class SceneChangerInstaller : ServicePrefabInstaller
    {
        [SerializeField] private SceneChanger prefab;
        
        public override void InstallService()
        {
            ProjectContext.Instance.SetServicePrefab<SceneChanger, SceneChanger>(prefab);
        }
    }
}