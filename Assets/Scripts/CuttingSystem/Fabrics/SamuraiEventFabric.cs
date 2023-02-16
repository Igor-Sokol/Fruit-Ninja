using BlockStackSystem;
using CuttingSystem.Implementations;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class SamuraiEventFabric : CuttingServiceFabric
    {
        [SerializeField] private BlockStackGenerator blockStackGenerator;
        [SerializeField] private SamuraiEventRenderer samuraiEventRenderer;
        
        public override ICuttingService Create()
        {
            return new SamuraiEvent(blockStackGenerator, samuraiEventRenderer);
        }
    }
}