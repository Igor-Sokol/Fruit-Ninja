using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "CutParticleSetting", menuName = "CuttingServicesSettings/CutParticleSetting")]
    public class CutParticleSetting : CuttingServiceSetting
    {
        [SerializeField] private ParticleSystem particle;
        
        public override Type CuttingServiceType => typeof(CutParticle);
        public override Type CuttingServiceFabricType => typeof(CutParticleFabric);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as CutParticle;
            if (implementation == null) return null;
            
            implementation.Init(particle);
            return implementation;
        }
    }
}