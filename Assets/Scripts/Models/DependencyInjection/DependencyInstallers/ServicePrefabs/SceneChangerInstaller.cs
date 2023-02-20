using GameSystems.SceneChangeSystem;
using Models.DependencyInjection.Contracts;
using UnityEngine;

namespace Models.DependencyInjection.DependencyInstallers.ServicePrefabs
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