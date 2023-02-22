using System;
using Blocks.BlockServices.BeyondZoneSystem.Implementations;
using UnityEngine;

namespace Blocks.BlockServices.BeyondZoneSystem.Factories
{
    [CreateAssetMenu(fileName = "DisableMimicEffects", menuName = "BeyondZoneSettings/DisableMimicEffects")]
    public class DisableMimicEffectsFactory : BeyondServiceFactory
    {
        public override Type CuttingServiceType => typeof(DisableMimicEffects);
        
        public override IBeyondService GetService()
        {
            return new DisableMimicEffects();
        }
    }
}