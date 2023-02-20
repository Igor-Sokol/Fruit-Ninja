using System;
using Blocks.BlockServices.BeyondZoneSystem.Implementations;
using GameSystems.HealthSystem;
using Models.DependencyInjection;
using UnityEngine;

namespace Blocks.BlockServices.BeyondZoneSystem.Factories
{
    [CreateAssetMenu(fileName = "LifeDecreaseSetting", menuName = "BeyondZoneSettings/LifeDecreaseSetting")]
    public class LifeDecreaseFactory : BeyondServiceFactory
    {
        public override Type CuttingServiceType => typeof(LifeDecrease);

        [SerializeField] private int damage;
        
        public override IBeyondService GetService()
        {
            var healthService = ProjectContext.Instance.GetService<HealthService>();

            var implementation = new LifeDecrease(healthService);
            implementation.Init(damage);
            return implementation;
        }
    }
}