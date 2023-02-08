using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "RemoveToPoolSetting", menuName = "CuttingServicesSettings/RemoveToPoolSetting")]
    public class RemoveToPoolSetting : CuttingServiceSetting
    {
        public override Type CuttingServiceType => typeof(RemoveToPool);
        public override Type CuttingServiceFabricType => typeof(RemoveToPoolFabric);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as RemoveToPool;
            return implementation;
        }
    }
}