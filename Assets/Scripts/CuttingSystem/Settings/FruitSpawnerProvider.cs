using System;
using BlockStackSystem;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "FruitSpawnerSetting", menuName = "CuttingServicesSettings/FruitSpawnerSetting")]
    public class FruitSpawnerProvider : CuttingServiceProvider
    {
        [SerializeField] private BlockStackSetting[] blockStackSettings;
        [SerializeField] private int count;
        [SerializeField] private float force;
        [SerializeField] private float spawnRange;
        [SerializeField] private float uncutTime;
        
        public override Type CuttingServiceType => typeof(FruitSpawner);
        public override Type CuttingServiceFactoryType => typeof(FruitSpawnerFactory);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFactoryContainer.Instance.GetServiceFabric(CuttingServiceFactoryType);
            if (!fabric) return null;

            var implementation = fabric.Create() as FruitSpawner;
            if (implementation == null) return null;
            
            implementation.Init(blockStackSettings, count, force, spawnRange, uncutTime);
            return implementation;
        }
    }
}