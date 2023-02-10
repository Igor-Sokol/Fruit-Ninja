using BlockComponents;
using HealthSystem;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class HealthChanger : ICuttingService
    {
        private readonly HealthService _healthService;
        private int _value;
        private HealthChangeMode _healthChangeMode;

        public void Init(int value, HealthChangeMode healthChangeMode)
        {
            _value = value;
            _healthChangeMode = healthChangeMode;
        }
        
        public HealthChanger(HealthService healthService)
        {
            _healthService = healthService;
        }

        public ServiceCallbackAction Cut(Block block, Vector2 bladeVector)
        {
            switch (_healthChangeMode)
            {
                case HealthChangeMode.Add:
                    _healthService.AddHealth(_value);
                    break;
                case HealthChangeMode.Remove:
                    _healthService.RemoveHealth(_value);
                    break;
            }

            return ServiceCallbackAction.None;
        }

        public enum HealthChangeMode
        {
            Add,
            Remove,
        }
    }
}