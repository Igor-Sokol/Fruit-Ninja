using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using Blocks.BlockStackSystem;
using Models.DependencyInjection;
using PlayingFieldComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "FruitSpawnerSetting", menuName = "CuttingServicesSettings/FruitSpawnerSetting")]
    public class FruitSpawnerFactory : CuttingServiceFactory
    {
        [SerializeField] private BlockStackSetting[] blockStackSettings;
        [SerializeField] private int count;
        [SerializeField] private float force;
        [SerializeField] private float spawnRange;
        [SerializeField] private float uncutTime;
        
        public override Type CuttingServiceType => typeof(FruitSpawner);

        public override ICuttingService GetService()
        {
            var playingFieldContainer = ProjectContext.Instance.GetService<BlockContainer>();
            var blockStackGenerator = ProjectContext.Instance.GetService<BlockStackGenerator>();

            var implementation = new FruitSpawner(playingFieldContainer, blockStackGenerator);
            implementation.Init(blockStackSettings, count, force, spawnRange, uncutTime);
            return implementation;
        }
    }
}