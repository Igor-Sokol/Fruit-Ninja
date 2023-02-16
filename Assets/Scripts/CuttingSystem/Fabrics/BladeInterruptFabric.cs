using CuttingSystem.Implementations;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class BladeInterruptFabric : CuttingServiceFabric
    {
        [SerializeField] private BladeMover bladeMover;
        
        public override ICuttingService Create()
        {
            return new BladeInterrupt(bladeMover);
        }
    }
}