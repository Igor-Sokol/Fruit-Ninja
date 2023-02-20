using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using PlayingFieldServices.Settings;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "MakeMagnetField", menuName = "CuttingServicesSettings/MakeMagnetField")]
    public class MakeMagnetFieldProviders : CuttingServiceProvider
    {
        [SerializeField] private MagnetFieldSettings magnetFieldSettings;
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private float seconds;
        
        public override Type CuttingServiceType => typeof(MakeMagnetField);
        public override Type CuttingServiceFactoryType => typeof(MakeMagnetFactory);
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as MakeMagnetField;
            if (implementation == null) return null;
            
            implementation.Init(magnetFieldSettings, particle, seconds);
            return implementation;
        }
    }
}