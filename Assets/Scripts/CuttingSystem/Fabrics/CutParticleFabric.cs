using CuttingSystem.Implementations;

namespace CuttingSystem.Fabrics
{
    public class CutParticleFabric : CuttingServiceFabric
    {
        public override ICuttingService Create()
        {
            return new CutParticle();
        }
    }
}