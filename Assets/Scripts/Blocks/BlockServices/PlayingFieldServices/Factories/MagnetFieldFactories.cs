using System;
using BlockConfiguration;
using DependencyInjection;
using PlayingFieldComponents;
using PlayingFieldServices.Implementations;
using UnityEngine;

namespace PlayingFieldServices.Settings
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