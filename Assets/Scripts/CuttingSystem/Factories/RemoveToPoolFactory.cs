using BlockStackSystem;
using CuttingSystem.Implementations;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class RemoveToPoolFactory : CuttingServiceFactory
    {
        [SerializeField] private BlockContainer playingFieldBlocks;
        [SerializeField] private BlockStackGenerator blockStackGenerator;
        
        public override ICuttingService Create()
        {
            return new RemoveToPool(playingFieldBlocks, blockStackGenerator);
        }
    }
}