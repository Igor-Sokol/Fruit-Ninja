using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using Models.DependencyInjection;
using PlayingFieldComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "ExplodeSetting", menuName = "CuttingServicesSettings/ExplodeSetting")]
    public class ExplodeFactory : CuttingServiceFactory
    {
        [SerializeField] private float range;
        [SerializeField] private float force;
        
        public override Type CuttingServiceType => typeof(Explode);

        public override ICuttingService GetService()
        {
            var blockContainer = ProjectContext.Instance.GetService<BlockContainer>();
            
            var implementation =  new Explode(blockContainer);
            implementation.Init(range, force);
            return implementation;
        }
    }
}