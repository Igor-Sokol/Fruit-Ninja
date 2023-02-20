using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "CutParticleSetting", menuName = "CuttingServicesSettings/CutParticleSetting")]
    public class CutParticleFactory : CuttingServiceFactory
    {
        [SerializeField] private ParticleSystem particle;
        
        public override Type CuttingServiceType => typeof(CutParticle);

        public override ICuttingService GetService()
        {
            var implementation = new CutParticle();
            implementation.Init(particle);
            return implementation;
        }
    }
}