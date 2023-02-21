using Blocks.BlockStackSystem;
using Models.DependencyInjection.Contracts;
using PlayingFieldComponents;
using UnityEngine;

namespace Models.DependencyInjection.DependencyInstallers.Services
{
    public class PlayingFieldInstaller : ServiceInstaller
    {
        private ProjectContext _projectContext;
        
        [SerializeField] private BlockContainer playingFieldContainer;
        [SerializeField] private BlockStackGenerator stackGenerator;

        public override ProjectContext ProjectContext { get => _projectContext ??= ProjectContext.Instance; set => _projectContext = value; }
        
        private void Awake()
        {
            InstallService();
        }
        
        public override void InstallService()
        {
            ProjectContext.SetService<BlockContainer, BlockContainer>(playingFieldContainer);
            ProjectContext.SetService<BlockStackGenerator, BlockStackGenerator>(stackGenerator);
        }
    }
}