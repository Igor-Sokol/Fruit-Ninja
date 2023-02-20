using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using Particles;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "CutTextParticleSetting", menuName = "CuttingServicesSettings/CutTextParticleSetting")]
    public class CutTextParticleProvider : CuttingServiceProvider
    {
        [SerializeField] private TextParticle textParticle;
        [SerializeField] private string text;
        
        public override Type CuttingServiceType => typeof(CutTextParticle);
        public override Type CuttingServiceFactoryType => typeof(CutTextParticleFactory);

        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as CutTextParticle;
            if (implementation == null) return null;
            
            implementation.Init(textParticle, text);
            return implementation;
        }
    }
}