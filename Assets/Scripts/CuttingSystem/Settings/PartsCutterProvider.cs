using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "PartsCutterSetting", menuName = "CuttingServicesSettings/PartsCutterSetting")]
    public class PartsCutterProvider : CuttingServiceProvider
    {
        [SerializeField] private float partsForce;
        
        public override Type CuttingServiceType => typeof(PartsCutter);
        public override Type CuttingServiceFactoryType => typeof(PartsCutterFactory);

        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as PartsCutter;
            if (implementation == null) return null;
            
            implementation.Init(partsForce);
            return implementation;
        }
    }
}