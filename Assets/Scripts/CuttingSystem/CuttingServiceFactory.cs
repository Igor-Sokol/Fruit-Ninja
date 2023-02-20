using UnityEngine;

namespace CuttingSystem
{
    public abstract class CuttingServiceFactory : MonoBehaviour, ICuttingServiceFactory
    {
        public abstract ICuttingService Create();
    }
}