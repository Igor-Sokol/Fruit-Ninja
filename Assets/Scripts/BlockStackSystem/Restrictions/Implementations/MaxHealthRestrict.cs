using HealthSystem;
using UnityEngine;

namespace BlockStackSystem.Restrictions.Implementations
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