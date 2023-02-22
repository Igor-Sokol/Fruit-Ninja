using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "DisableMimic", menuName = "CuttingServicesSettings/DisableMimic")]
    public class DisableMimicFactory : CuttingServiceFactory
    {
        public override Type CuttingServiceType => typeof(DisableMimic);
        public override ICuttingService GetService()
        {
            return new DisableMimic();
        }
    }
}