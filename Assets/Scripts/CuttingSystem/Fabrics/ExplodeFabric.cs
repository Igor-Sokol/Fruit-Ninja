using CuttingSystem.Implementations;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class ExplodeFabric : CuttingServiceFabric
    {
        [SerializeField] private BlockContainer playingFieldBlocks;
        [SerializeField] private BlockPool blockPool;
        
        public override ICuttingService Create()
        {
            return new Explode(playingFieldBlocks, blockPool);
        }
    }
}