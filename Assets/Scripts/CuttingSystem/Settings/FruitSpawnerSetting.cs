using System;
using BlockStackSystem;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "FruitSpawnerSetting", menuName = "CuttingServicesSettings/FruitSpawnerSetting")]
    public class FruitSpawnerSetting : CuttingServiceSetting
    {
        [SerializeField] private BlockStackSetting[] blockStackSettings;
        [SerializeField] private int count;
        [SerializeField] private float force;
        [SerializeField] private float spawnRange;
        [SerializeField] private Vector2 spawnOffset;
        
        public override Type CuttingServiceType => typeof(FruitSpawner);
        public override Type CuttingServiceFabricType => typeof(FruitSpawnerFabric);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as FruitSpawner;
            if (implementation == null) return null;
            
            implementation.Init(blockStackSettings, count, force, spawnRange, spawnOffset);
            return implementation;
        }
    }
}