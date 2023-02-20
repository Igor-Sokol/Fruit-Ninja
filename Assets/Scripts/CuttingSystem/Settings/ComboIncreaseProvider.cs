using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "ComboIncreaseSetting", menuName = "CuttingServicesSettings/ComboIncreaseSetting")]
    public class ComboIncreaseProvider : CuttingServiceProvider
    {
        [SerializeField] private bool changeComboPosition;
        
        public override Type CuttingServiceType => typeof(ComboIncrease);
        public override Type CuttingServiceFactoryType => typeof(ComboIncreaseFactory);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as ComboIncrease;
            if (implementation == null) return null;
            
            implementation.Init(changeComboPosition);
            return implementation;
        }
    }
}