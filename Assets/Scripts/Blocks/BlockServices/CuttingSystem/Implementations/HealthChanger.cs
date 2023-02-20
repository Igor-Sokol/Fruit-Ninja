using BlockComponents;
using HealthSystem;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class HealthChanger : ICuttingService
    {
        private readonly HealthService _healthService;
        private readonly HealthView _healthView;
        private int _value;
        private HealthChangeMode _healthChangeMode;

        public void Init(int value, HealthChangeMode healthChangeMode)
        {
            _value = value;
            _healthChangeMode = healthChangeMode;
        }
        
        public HealthChanger(HealthService healthService, HealthView healthView)
        {
            _healthService = healthService;
            _healthView = healthView;
        }

        public void Cut(Block block, Vector2 bladeVector)
        {
            switch (_healthChangeMode)
            {
                case HealthChangeMode.Add:
                    _healthView.SetSpawnPosition(block.transform.position);
                    _healthService.AddHealth(_value);
                    break;
                case HealthChangeMode.Remove:
                    _healthService.RemoveHealth(_value);
                    break;
            }
        }

        public enum HealthChangeMode
        {
            Add,
            Remove,
        }
    }
}