using BlockStackSystem;
using CuttingSystem.Implementations;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class FruitSpawnerFabric : CuttingServiceFabric
    {
        [SerializeField] private BlockContainer playingFieldContainer;
        [SerializeField] private BlockStackGenerator blockStackGenerator;
        
        public override ICuttingService Create()
        {
            return new FruitSpawner(playingFieldContainer, blockStackGenerator);
        }
    }
}