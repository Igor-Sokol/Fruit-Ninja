using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "BladeInterrupt", menuName = "CuttingServicesSettings/BladeInterrupt")]
    public class BladeInterruptSetting : CuttingServiceSetting
    {
        public override Type CuttingServiceType => typeof(BladeInterrupt);
        public override Type CuttingServiceFabricType => typeof(BladeInterruptFabric);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as BladeInterrupt;
            return implementation;
        }
    }
}