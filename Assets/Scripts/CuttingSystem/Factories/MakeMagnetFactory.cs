using CuttingSystem.Implementations;

namespace CuttingSystem.Fabrics
{
    public class MakeMagnetFactory : CuttingServiceFactory
    {
        public override ICuttingService Create()
        {
            return new MakeMagnetField();
        }
    }
}