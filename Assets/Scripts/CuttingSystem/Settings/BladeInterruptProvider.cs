using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Factories;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "BladeInterrupt", menuName = "CuttingServicesSettings/BladeInterrupt")]
    public class BladeInterruptProvider : CuttingServiceProvider
    {
        public override Type CuttingServiceType => typeof(BladeInterrupt);
        public override Type CuttingServiceFactoryType => typeof(BladeInterruptFactory);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as BladeInterrupt;
            return implementation;
        }
    }
}