using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using Managers;
using Models.DependencyInjection;
using UI;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "TimeSlowerSetting", menuName = "CuttingServicesSettings/TimeSlowerSetting")]
    public class TimeSlowerFactory : CuttingServiceFactory
    {
        [SerializeField] private float scale;
        [SerializeField] private float slowSeconds;

        public override Type CuttingServiceType => typeof(TimeSlower);

        public override ICuttingService GetService()
        {
            var timeScaleManager = ProjectContext.Instance.GetService<TimeScaleManager>();
            var filterRenderer = ProjectContext.Instance.GetService<FilterRenderer>();

            var implementation = new TimeSlower(timeScaleManager, filterRenderer);
            implementation.Init(scale, slowSeconds);
            return implementation;
        }
    }
}