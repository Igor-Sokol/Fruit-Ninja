using BlockStackSystem;
using CuttingSystem.Implementations;
using PlayingFieldComponents;
using UnityEngine;
using UnityEngine.Serialization;

namespace CuttingSystem.Fabrics
{
    public class PartsCutterFactory : CuttingServiceFactory
    {
        [SerializeField] private BlockContainer playingBlockContainer;
        [SerializeField] private BlockStackGenerator blockStackGenerator;


        public override ICuttingService Create()
        {
            return new PartsCutter(playingBlockContainer, blockStackGenerator);
        }
    }
}