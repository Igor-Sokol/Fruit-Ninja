using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "BlotParticleSetting", menuName = "CuttingServicesSettings/BlotParticleSetting")]
    public class BlotParticleSetting : CuttingServiceSetting
    {
        public override Type CuttingServiceType => typeof(BlotParticle);
        public override Type CuttingServiceFabricType => typeof(BlotParticleFabric);

        [SerializeField] private ParticleSystem particle;
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as BlotParticle;
            if (implementation == null) return null;
            
            implementation.Init(particle);
            return implementation;
        }
    }
}