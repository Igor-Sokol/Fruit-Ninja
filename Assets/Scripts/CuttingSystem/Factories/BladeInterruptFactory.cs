using CuttingSystem.Implementations;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Factories
{
    public class BladeInterruptFactory : CuttingServiceFactory
    {
        [SerializeField] private BladeMover bladeMover;
        
        public override ICuttingService Create()
        {
            return new BladeInterrupt(bladeMover);
        }
    }
}