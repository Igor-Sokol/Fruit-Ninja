using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "TimeSlowerSetting", menuName = "CuttingServicesSettings/TimeSlowerSetting")]
    public class TimeSlowerProvider : CuttingServiceProvider
    {
        [SerializeField] private float scale;
        [SerializeField] private float slowSeconds;

        public override Type CuttingServiceType => typeof(TimeSlower);
        public override Type CuttingServiceFactoryType => typeof(TimeSlowerFactory);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as TimeSlower;
            if (implementation == null) return null;
            
            implementation.Init(scale, slowSeconds);
            return implementation;
        }
    }
}