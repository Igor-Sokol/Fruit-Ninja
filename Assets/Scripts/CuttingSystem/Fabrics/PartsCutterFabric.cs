using CuttingSystem.Implementations;
using PlayingFieldComponents;
using UnityEngine;
using UnityEngine.Serialization;

namespace CuttingSystem.Fabrics
{
    public class PartsCutterFabric : CuttingServiceFabric
    {
        [SerializeField] private BlockContainer playingBlockContainer;
        [SerializeField] private BlockStackGenerator blockStackGenerator;


        public override ICuttingService Create()
        {
            return new PartsCutter(playingBlockContainer, blockStackGenerator);
        }
    }
}