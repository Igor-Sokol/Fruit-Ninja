using GameSystems.HealthSystem;
using Models.DependencyInjection.Contracts;
using UI;
using UI.Game;
using UnityEngine;

namespace Models.DependencyInjection.DependencyInstallers.Services
{
    public class UIRendererInstaller : ServiceInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private HealthView healthView;
        [SerializeField] private BladeMover bladeMover;
        [SerializeField] private FilterRenderer filterRenderer;
        [SerializeField] private SamuraiEventRenderer samuraiEventRenderer;
        [SerializeField] private ComboRenderer comboRenderer;

        private void Awake()
        {
            InstallService();
        }

        public override void InstallService()
        {
            ProjectContext.Instance.SetService<Canvas, Canvas>(canvas);
            ProjectContext.Instance.SetService<HealthView, HealthView>(healthView);
            ProjectContext.Instance.SetService<BladeMover, BladeMover>(bladeMover);
            ProjectContext.Instance.SetService<FilterRenderer, FilterRenderer>(filterRenderer);
            ProjectContext.Instance.SetService<SamuraiEventRenderer, SamuraiEventRenderer>(samuraiEventRenderer);
            ProjectContext.Instance.SetService<ComboRenderer, ComboRenderer>(comboRenderer);
        }
    }
}