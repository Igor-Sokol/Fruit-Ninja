using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "CutParticleSetting", menuName = "CuttingServicesSettings/CutParticleSetting")]
    public class CutParticleProvider : CuttingServiceProvider
    {
        [SerializeField] private ParticleSystem particle;
        
        public override Type CuttingServiceType => typeof(CutParticle);
        public override Type CuttingServiceFactoryType => typeof(CutParticleFactory);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as CutParticle;
            if (implementation == null) return null;
            
            implementation.Init(particle);
            return implementation;
        }
    }
}