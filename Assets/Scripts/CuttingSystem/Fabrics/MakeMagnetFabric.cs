using CuttingSystem.Implementations;

namespace CuttingSystem.Fabrics
{
    public class MakeMagnetFabric : CuttingServiceFabric
    {
        public override ICuttingService Create()
        {
            return new MakeMagnetField();
        }
    }
}