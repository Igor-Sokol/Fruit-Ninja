using Models.DependencyInjection.Contracts;
using Models.PopUpSystem;
using UnityEngine;

namespace Models.DependencyInjection.DependencyInstallers.Services
{
    public class PopUpManagerInstaller : ServiceInstaller
    {
        private ProjectContext _projectContext;
        
        [SerializeField] private PopUpManager popUpManager;

        public override ProjectContext ProjectContext { get => _projectContext ??= ProjectContext.Instance; set => _projectContext = value; }

        public override void InstallService()
        {
            ProjectContext.SetService<PopUpManager, PopUpManager>(popUpManager);
        }
    }
}