using CuttingSystem.Implementations;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class CutTextParticleFactory : CuttingServiceFactory
    {
        [SerializeField] private Transform canvas;
        
        public override ICuttingService Create()
        {
            return new CutTextParticle(canvas);
        }
    }
}