using System;
using BlockStackSystem;
using CuttingSystem.Implementations;
using DependencyInjection;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Settings
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