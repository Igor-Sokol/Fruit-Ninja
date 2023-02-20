using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using Blocks.BlockStackSystem;
using Models.DependencyInjection;
using PlayingFieldComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "RemoveToPoolSetting", menuName = "CuttingServicesSettings/RemoveToPoolSetting")]
    public class RemoveToPoolFactory : CuttingServiceFactory
    {
        public override Type CuttingServiceType => typeof(RemoveToPool);

        public override ICuttingService GetService()
        {
            var playingFieldBlocks = ProjectContext.Instance.GetService<BlockContainer>();
            var blockStackGenerator = ProjectContext.Instance.GetService<BlockStackGenerator>();

            var implementation = new RemoveToPool(playingFieldBlocks, blockStackGenerator);
            return implementation;
        }
    }
}