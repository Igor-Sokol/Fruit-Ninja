using GameSystems.HealthSystem;
using Models.DependencyInjection.Contracts;
using Models.PopUpSystem.Contracts;
using UI;
using UI.Game;
using UnityEngine;

namespace Models.DependencyInjection.DependencyInstallers.Services
{
    public class UIRendererInstaller : ServiceInstaller
    {
        private ProjectContext _projectContext;
        
        [SerializeField] private Canvas canvas;
        [SerializeField] private HealthView healthView;
        [SerializeField] private BladeMover bladeMover;
        [SerializeField] private FilterRenderer filterRenderer;
        [SerializeField] private SamuraiEventRenderer samuraiEventRenderer;
        [SerializeField] private ComboRenderer comboRenderer;
        [SerializeField] private PopUpContainer popUpContainer;
        [SerializeField] private MobileBlur gameBlur;

        public override ProjectContext ProjectContext { get => _projectContext ??= ProjectContext.Instance; set => _projectContext = value; }
        
        private void Awake()
        {
            InstallService();
        }

        public override void InstallService()
        {
            ProjectContext.SetService<Canvas, Canvas>(canvas);
            ProjectContext.SetService<HealthView, HealthView>(healthView);
            ProjectContext.SetService<BladeMover, BladeMover>(bladeMover);
            ProjectContext.SetService<FilterRenderer, FilterRenderer>(filterRenderer);
            ProjectContext.SetService<SamuraiEventRenderer, SamuraiEventRenderer>(samuraiEventRenderer);
            ProjectContext.SetService<ComboRenderer, ComboRenderer>(comboRenderer);
            ProjectContext.SetService<PopUpContainer, PopUpContainer>(popUpContainer);
            ProjectContext.SetService<MobileBlur, MobileBlur>(gameBlur);
        }
    }
}