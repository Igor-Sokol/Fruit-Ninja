using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "ExplodeSetting", menuName = "CuttingServicesSettings/ExplodeSetting")]
    public class ExplodeProvider : CuttingServiceProvider
    {
        [SerializeField] private float range;
        [SerializeField] private float force;
        
        public override Type CuttingServiceType => typeof(Explode);
        public override Type CuttingServiceFactoryType => typeof(ExplodeFactory);

        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as Explode;
            if (implementation == null) return null;
            
            implementation.Init(range, force);
            return implementation;
        }
    }
}