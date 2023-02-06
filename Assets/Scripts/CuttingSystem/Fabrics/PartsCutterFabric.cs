using CuttingSystem.Implementations;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class PartsCutterFabric : CuttingServiceFabric
    {
        [SerializeField] private BlockContainer playingBlockContainer;
        [SerializeField] private BlockPool blockPool;


        public override ICuttingService Create()
        {
            return new PartsCutter(playingBlockContainer, blockPool);
        }
    }
}