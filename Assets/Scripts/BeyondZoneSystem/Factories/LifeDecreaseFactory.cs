using BeyondZoneSystem.Implementations;
using HealthSystem;
using UnityEngine;

namespace BeyondZoneSystem.Factories
{
    public class LifeDecreaseFactory : BeyondServiceFactory
    {
        [SerializeField] private HealthService healthService;
        
        public override IBeyondService Create()
        {
            return new LifeDecrease(healthService);
        }
    }
}