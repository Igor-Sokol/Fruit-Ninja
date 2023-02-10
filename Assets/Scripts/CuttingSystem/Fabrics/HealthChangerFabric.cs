using CuttingSystem.Implementations;
using HealthSystem;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class HealthChangerFabric : CuttingServiceFabric
    {
        [SerializeField] private HealthService healthService;
        [SerializeField] private HealthView healthView;
        
        public override ICuttingService Create()
        {
            return new HealthChanger(healthService, healthView);
        }
    }
}