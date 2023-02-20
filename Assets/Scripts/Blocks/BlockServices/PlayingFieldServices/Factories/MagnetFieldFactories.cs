using System;
using Blocks.BlockConfiguration;
using Blocks.BlockServices.PlayingFieldServices.Implementations;
using Models.DependencyInjection;
using PlayingFieldComponents;
using UnityEngine;

namespace Blocks.BlockServices.PlayingFieldServices.Factories
{
    [CreateAssetMenu(fileName = "MagnetField", menuName = "PlayingFieldService/MagnetField")]
    public class MagnetFieldFactories : PlayingFieldServiceFactory
    {
        [SerializeField] private float force;
        [SerializeField] private BlockSettingObject[] influenceExclusions;
        
        public override Type CuttingServiceType => typeof(MagnetField);

        public override IPlayingFieldService GetService()
        {
            var blockContainer = ProjectContext.Instance.GetService<BlockContainer>();
            
            var implementation = new MagnetField(blockContainer);
            implementation.Init(force, influenceExclusions);
            return implementation;
        }
    }
}