using System;
using BlockStackSystem;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using DifficultySystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "SamuraiEvent", menuName = "CuttingServicesSettings/SamuraiEvent")]
    public class SamuraiEventProviders : CuttingServiceProvider
    {
        public override Type CuttingServiceType => typeof(SamuraiEvent);
        public override Type CuttingServiceFactoryType => typeof(SamuraiEventFactory);
        
        [SerializeField] private StaticSetting difficultySetting;
        [SerializeField] private BlockStackSetting[] stackSettings;
        [SerializeField] private float time;
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as SamuraiEvent;
            if (implementation == null) return null;
            
            implementation.Init(difficultySetting, stackSettings, time);
            return implementation;
        }
    }
}