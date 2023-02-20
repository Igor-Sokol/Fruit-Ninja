using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "RemoveToPoolSetting", menuName = "CuttingServicesSettings/RemoveToPoolSetting")]
    public class RemoveToPoolProvider : CuttingServiceProvider
    {
        public override Type CuttingServiceType => typeof(RemoveToPool);
        public override Type CuttingServiceFactoryType => typeof(RemoveToPoolFactory);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as RemoveToPool;
            return implementation;
        }
    }
}