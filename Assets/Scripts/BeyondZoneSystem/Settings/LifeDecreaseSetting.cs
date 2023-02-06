using System;
using BeyondZoneSystem.Fabrics;
using BeyondZoneSystem.Implementations;
using UnityEngine;

namespace BeyondZoneSystem.Settings
{
    [CreateAssetMenu(fileName = "LifeDecreaseSetting", menuName = "BeyondZoneSettings/LifeDecreaseSetting")]
    public class LifeDecreaseSetting : BeyondServiceSetting
    {
        public override Type CuttingServiceType => typeof(LifeDecrease);
        public override Type CuttingServiceFabricType => typeof(LifeDecreaseFabric);

        [SerializeField] private int damage;
        
        public override IBeyondService GetService()
        {
            var fabric = BeyondServiceLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as LifeDecrease;
            if (implementation == null) return null;
            
            implementation.Init(damage);
            return implementation;
        }
    }
}