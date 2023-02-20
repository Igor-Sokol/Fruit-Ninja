using CuttingSystem.Implementations;

namespace CuttingSystem.Fabrics
{
    public class CutParticleFactory : CuttingServiceFactory
    {
        public override ICuttingService Create()
        {
            return new CutParticle();
        }
    }
}