using System;
using BlockStackSystem;
using CuttingSystem.Implementations;
using DependencyInjection;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Settings
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