using UnityEngine;

namespace BeyondZoneSystem
{
    public abstract class BeyondServiceFactory : MonoBehaviour, IBeyondServiceFactory
    {
        public abstract IBeyondService Create();
    }
}