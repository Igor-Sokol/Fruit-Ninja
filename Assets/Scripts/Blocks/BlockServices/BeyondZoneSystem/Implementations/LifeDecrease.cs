using Blocks.BlockComponents;
using GameSystems.HealthSystem;

namespace Blocks.BlockServices.BeyondZoneSystem.Implementations
{
    public class LifeDecrease : IBeyondService
    {
        private readonly HealthService _healthService;
        private int _damage;

        public void Init(int damage)
        {
            _damage = damage;
        }
        
        public LifeDecrease(HealthService healthService)
        {
            _healthService = healthService;
        }
        
        public void BeyondZoneAction(Block block)
        {
            _healthService.RemoveHealth(_damage);
        }
    }
}