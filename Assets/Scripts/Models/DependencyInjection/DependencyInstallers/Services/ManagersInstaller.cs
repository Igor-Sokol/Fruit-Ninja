using GameSystems.HealthSystem;
using GameSystems.ScoreSystem;
using Managers;
using Models.DependencyInjection.Contracts;
using UnityEngine;

namespace Models.DependencyInjection.DependencyInstallers.Services
{
    public class ManagersInstaller : ServiceInstaller
    {
        private ProjectContext _projectContext;
        
        [SerializeField] private TimeScaleManager timeScaleManager;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private ComboManager comboManager;
        [SerializeField] private HealthService healthService;
        
        public override ProjectContext ProjectContext { get => _projectContext ??= ProjectContext.Instance; set => _projectContext = value; }
        
        private void Awake()
        {
            InstallService();
        }
        
        public override void InstallService()
        {
            ProjectContext.SetService<TimeScaleManager, TimeScaleManager>(timeScaleManager);
            ProjectContext.SetService<ScoreManager, ScoreManager>(scoreManager);
            ProjectContext.SetService<ComboManager, ComboManager>(comboManager);
            ProjectContext.SetService<HealthService, HealthService>(healthService);
        }
    }
}