using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using Blocks.BlockStackSystem;
using Models.DependencyInjection;
using PlayingFieldComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "PartsCutterSetting", menuName = "CuttingServicesSettings/PartsCutterSetting")]
    public class PartsCutterFactory : CuttingServiceFactory
    {
        [SerializeField] private float partsForce;
        
        public override Type CuttingServiceType => typeof(PartsCutter);

        public override ICuttingService GetService()
        {
            var playingBlockContainer = ProjectContext.Instance.GetService<BlockContainer>();
            var blockStackGenerator = ProjectContext.Instance.GetService<BlockStackGenerator>();

            var implementation = new PartsCutter(playingBlockContainer, blockStackGenerator);
            implementation.Init(partsForce);
            return implementation;
        }
    }
}