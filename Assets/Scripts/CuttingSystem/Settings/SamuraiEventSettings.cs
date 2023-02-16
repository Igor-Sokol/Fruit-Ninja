using System;
using BlockStackSystem;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using DifficultySystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "SamuraiEvent", menuName = "CuttingServicesSettings/SamuraiEvent")]
    public class SamuraiEventSettings : CuttingServiceSetting
    {
        public override Type CuttingServiceType => typeof(SamuraiEvent);
        public override Type CuttingServiceFabricType => typeof(SamuraiEventFabric);
        
        [SerializeField] private StaticSetting difficultySetting;
        [SerializeField] private BlockStackSetting[] stackSettings;
        [SerializeField] private float time;
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as SamuraiEvent;
            if (implementation == null) return null;
            
            implementation.Init(difficultySetting, stackSettings, time);
            return implementation;
        }
    }
}