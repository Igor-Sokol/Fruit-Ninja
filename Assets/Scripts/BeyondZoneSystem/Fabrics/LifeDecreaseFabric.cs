using BeyondZoneSystem.Implementations;
using HealthSystem;
using UnityEngine;

namespace BeyondZoneSystem.Fabrics
{
    public class LifeDecreaseFabric : BeyondServiceFabric
    {
        [SerializeField] private HealthService healthService;
        
        public override IBeyondService Create()
        {
            return new LifeDecrease(healthService);
        }
    }
}