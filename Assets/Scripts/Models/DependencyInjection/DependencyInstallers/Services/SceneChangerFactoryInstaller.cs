using GameSystems.SceneChangeSystem;
using Models.DependencyInjection.Contracts;
using Models.Factories.Contracts.Generic;
using Models.Factories.Implementations;

namespace Models.DependencyInjection.DependencyInstallers.Services
{
    public class SceneChangerFactoryInstaller : ServiceInstaller
    {
        public override void InstallService()
        {
            ProjectContext.Instance.SetService<IFactory<SceneChanger>, SceneChangerFactory>(new SceneChangerFactory());
        }
    }
}