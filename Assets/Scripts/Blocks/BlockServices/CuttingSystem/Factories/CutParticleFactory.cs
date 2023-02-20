using System;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
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