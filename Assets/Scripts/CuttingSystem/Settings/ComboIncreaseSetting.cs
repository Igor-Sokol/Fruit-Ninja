using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "ComboIncreaseSetting", menuName = "CuttingServicesSettings/ComboIncreaseSetting")]
    public class ComboIncreaseSetting : CuttingServiceSetting
    {
        [SerializeField] private bool changeComboPosition;
        
        public override Type CuttingServiceType => typeof(ComboIncrease);
        public override Type CuttingServiceFabricType => typeof(ComboIncreaseFabric);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as ComboIncrease;
            if (implementation == null) return null;
            
            implementation.Init(changeComboPosition);
            return implementation;
        }
    }
}