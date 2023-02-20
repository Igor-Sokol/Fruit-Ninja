using GameSystems.HealthSystem;
using UnityEngine;

namespace Blocks.BlockStackSystem.Restrictions.Implementations
{
    public class MaxHealthRestrict : Restriction
    {
        [SerializeField] private HealthService healthService;
        
        public override bool IsRestricted()
        {
            return healthService.Health >= healthService.MaxHealth;
        }
    }
}