using CuttingSystem.Implementations;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class ExplodeFactory : CuttingServiceFactory
    {
        [SerializeField] private BlockContainer playingFieldBlocks;

        public override ICuttingService Create()
        {
            return new Explode(playingFieldBlocks);
        }
    }
}