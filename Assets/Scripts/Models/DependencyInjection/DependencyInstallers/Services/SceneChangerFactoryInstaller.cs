using DependencyInjection.Contracts;
using Factories.Contracts.Generic;
using Factories.Implementations;
using SceneChangeSystem;

namespace DependencyInjection.DependencyInstallers.Services
{
    public class SceneChangerFactoryInstaller : ServiceInstaller
    {
        public override void InstallService()
        {
            ProjectContext.Instance.SetService<IFactory<SceneChanger>, SceneChangerFactory>(new SceneChangerFactory());
        }
    }
}