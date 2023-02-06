using UnityEngine;

namespace BeyondZoneSystem
{
    public abstract class BeyondServiceFabric : MonoBehaviour, IBeyondServiceFabric
    {
        public abstract IBeyondService Create();
    }
}