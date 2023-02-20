using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using GameSystems.HealthSystem;
using Models.DependencyInjection;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "HealthChangerSetting", menuName = "CuttingServicesSettings/HealthChangerSetting")]
    public class HealthChangerFactory : CuttingServiceFactory
    {
        [SerializeField] private HealthChanger.HealthChangeMode healthChangeMode;
        [SerializeField] private int value;
        
        public override Type CuttingServiceType => typeof(HealthChanger);

        public override ICuttingService GetService()
        {
            var healthService = ProjectContext.Instance.GetService<HealthService>();
            var healthView = ProjectContext.Instance.GetService<HealthView>();

            var implementation = new HealthChanger(healthService, healthView);
            implementation.Init(value, healthChangeMode);
            return implementation;
        }
    }
}