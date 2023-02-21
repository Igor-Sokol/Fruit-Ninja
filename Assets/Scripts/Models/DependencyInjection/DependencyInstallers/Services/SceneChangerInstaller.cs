using GameSystems.SceneChangeSystem;
using Models.DependencyInjection.Contracts;
using UnityEngine;

namespace Models.DependencyInjection.DependencyInstallers.Services
{
    public class SceneChangerInstaller : ServiceInstaller
    {
        private ProjectContext _projectContext;
        
        [SerializeField] private SceneChanger sceneChanger;

        public override ProjectContext ProjectContext { get => _projectContext ??= ProjectContext.Instance; set => _projectContext = value; }

        public override void InstallService()
        {
            ProjectContext.SetService<SceneChanger, SceneChanger>(sceneChanger);
        }
    }
}