using CodeStage.AdvancedFPSCounter;
using Models.DependencyInjection.Contracts;
using UnityEngine;

namespace Models.DependencyInjection.DependencyInstallers.Services
{
    public class FPSInstaller : ServiceInstaller
    {
        [SerializeField] private AFPSCounter aFPSCounterPrefab;
        
        public override ProjectContext ProjectContext { get; set; }
        public override void InstallService()
        {
#if FPS_DEBUG
            var instance = Instantiate(aFPSCounterPrefab, transform);
            ProjectContext.SetService<AFPSCounter, AFPSCounter>(instance);
#endif
        }
    }
}