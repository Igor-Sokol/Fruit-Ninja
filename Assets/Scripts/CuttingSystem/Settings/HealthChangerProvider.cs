using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "HealthChangerSetting", menuName = "CuttingServicesSettings/HealthChangerSetting")]
    public class HealthChangerProvider : CuttingServiceProvider
    {
        [SerializeField] private HealthChanger.HealthChangeMode healthChangeMode;
        [SerializeField] private int value;
        
        public override Type CuttingServiceType => typeof(HealthChanger);
        public override Type CuttingServiceFactoryType => typeof(HealthChangerFactory);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as HealthChanger;
            if (implementation == null) return null;
            
            implementation.Init(value, healthChangeMode);
            return implementation;
        }
    }
}