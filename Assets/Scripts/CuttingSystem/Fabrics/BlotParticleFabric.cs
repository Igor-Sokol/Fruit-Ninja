using CuttingSystem.Implementations;

namespace CuttingSystem.Fabrics
{
    public class BlotParticleFabric : CuttingServiceFabric
    {
        public override ICuttingService Create()
        {
            return new BlotParticle();
        }
    }
}