using System;
using CuttingSystem.Implementations;
using DependencyInjection;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Settings
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