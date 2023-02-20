using System;
using CuttingSystem.Implementations;
using DependencyInjection;
using Managers;
using UI;
using UnityEngine;

namespace CuttingSystem.Settings
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