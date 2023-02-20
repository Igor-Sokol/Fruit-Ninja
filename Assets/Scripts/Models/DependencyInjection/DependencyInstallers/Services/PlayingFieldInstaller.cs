using BlockStackSystem;
using DependencyInjection.Contracts;
using PlayingFieldComponents;
using UnityEngine;

namespace DependencyInjection.DependencyInstallers.Services
{
    public class PlayingFieldInstaller : ServiceInstaller
    {
        [SerializeField] private BlockContainer playingFieldContainer;
        [SerializeField] private BlockStackGenerator stackGenerator;

        private void Awake()
        {
            InstallService();
        }
        
        public override void InstallService()
        {
            ProjectContext.Instance.SetService<BlockContainer, BlockContainer>(playingFieldContainer);
            ProjectContext.Instance.SetService<BlockStackGenerator, BlockStackGenerator>(stackGenerator);
        }
    }
}