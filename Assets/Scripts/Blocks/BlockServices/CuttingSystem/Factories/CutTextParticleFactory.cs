using System;
using CuttingSystem.Implementations;
using DependencyInjection;
using Particles;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "CutTextParticleSetting", menuName = "CuttingServicesSettings/CutTextParticleSetting")]
    public class CutTextParticleFactory : CuttingServiceFactory
    {
        [SerializeField] private TextParticle textParticle;
        [SerializeField] private string text;
        
        public override Type CuttingServiceType => typeof(CutTextParticle);

        public override ICuttingService GetService()
        {
            var canvas = ProjectContext.Instance.GetService<Canvas>();
            
            var implementation = new CutTextParticle(canvas.transform);
            implementation.Init(textParticle, text);
            return implementation;
        }
    }
}