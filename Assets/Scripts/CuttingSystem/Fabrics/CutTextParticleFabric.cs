using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class CutTextParticleFabric : CuttingServiceFabric
    {
        [SerializeField] private Transform canvas;
        
        public override ICuttingService Create()
        {
            return new CutTextParticle(canvas);
        }
    }
}