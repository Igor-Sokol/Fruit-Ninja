using System;
using BeyondZoneSystem.Factories;
using BeyondZoneSystem.Implementations;
using UnityEngine;

namespace BeyondZoneSystem.Settings
{
    [CreateAssetMenu(fileName = "LifeDecreaseSetting", menuName = "BeyondZoneSettings/LifeDecreaseSetting")]
    public class LifeDecreaseProvider : BeyondServiceProvider
    {
        public override Type CuttingServiceType => typeof(LifeDecrease);
        public override Type CuttingServiceFactoryType => typeof(LifeDecreaseFactory);

        [SerializeField] private int damage;
        
        public override IBeyondService GetService()
        {
            var fabric = BeyondServiceContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as LifeDecrease;
            if (implementation == null) return null;
            
            implementation.Init(damage);
            return implementation;
        }
    }
}