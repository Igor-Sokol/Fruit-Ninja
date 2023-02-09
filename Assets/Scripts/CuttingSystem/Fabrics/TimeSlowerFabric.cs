using CuttingSystem.Implementations;
using Managers;
using UI;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class TimeSlowerFabric : CuttingServiceFabric
    {
        [SerializeField] private TimeScaleManager timeScaleManager;
        [SerializeField] private FilterRenderer filterRenderer;
        
        public override ICuttingService Create()
        {
            return new TimeSlower(timeScaleManager, filterRenderer);
        }
    }
}