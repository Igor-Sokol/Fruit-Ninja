using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using Blocks.BlockServices.PlayingFieldServices.Factories;
using UnityEngine;
using UnityEngine.Serialization;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "MakeMagnetField", menuName = "CuttingServicesSettings/MakeMagnetField")]
    public class MakeMagnetFieldFactories : CuttingServiceFactory
    {
        [FormerlySerializedAs("magnetFieldSettings")] [SerializeField] private MagnetFieldFactories magnetFieldFactories;
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private float seconds;
        
        public override Type CuttingServiceType => typeof(MakeMagnetField);
        
        public override ICuttingService GetService()
        {
            var implementation = new MakeMagnetField();
            implementation.Init(magnetFieldFactories, particle, seconds);
            return implementation;
        }
    }
}