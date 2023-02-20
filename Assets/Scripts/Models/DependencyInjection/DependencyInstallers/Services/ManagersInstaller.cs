using DependencyInjection.Contracts;
using HealthSystem;
using Managers;
using ScoreSystem;
using UnityEngine;

namespace DependencyInjection.DependencyInstallers.Services
{
    public class ManagersInstaller : ServiceInstaller
    {
        [SerializeField] private TimeScaleManager timeScaleManager;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private ComboManager comboManager;
        [SerializeField] private HealthService healthService;
        
        private void Awake()
        {
            InstallService();
        }
        
        public override void InstallService()
        {
            ProjectContext.Instance.SetService<TimeScaleManager, TimeScaleManager>(timeScaleManager);
            ProjectContext.Instance.SetService<ScoreManager, ScoreManager>(scoreManager);
            ProjectContext.Instance.SetService<ComboManager, ComboManager>(comboManager);
            ProjectContext.Instance.SetService<HealthService, HealthService>(healthService);
        }
    }
}