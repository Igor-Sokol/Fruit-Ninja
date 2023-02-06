using UnityEngine;

namespace CuttingSystem
{
    public abstract class CuttingServiceFabric : MonoBehaviour, ICuttingServiceFabric
    {
        public abstract ICuttingService Create();
    }
}