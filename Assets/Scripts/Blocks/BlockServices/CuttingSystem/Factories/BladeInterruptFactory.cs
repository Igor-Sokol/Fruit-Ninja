using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using Models.DependencyInjection;
using UI.Game;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "BladeInterrupt", menuName = "CuttingServicesSettings/BladeInterrupt")]
    public class BladeInterruptFactory : CuttingServiceFactory
    {
        public override Type CuttingServiceType => typeof(BladeInterrupt);

        public override ICuttingService GetService()
        {
            BladeMover bladeMover = ProjectContext.Instance.GetService<BladeMover>();
            return new BladeInterrupt(bladeMover);
        }
    }
}