using CuttingSystem.Implementations;
using Managers;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class TimeSlowerFabric : CuttingServiceFabric
    {
        [SerializeField] private TimeScaleManager timeScaleManager;
        
        public override ICuttingService Create()
        {
            return new TimeSlower(timeScaleManager);
        }
    }
}