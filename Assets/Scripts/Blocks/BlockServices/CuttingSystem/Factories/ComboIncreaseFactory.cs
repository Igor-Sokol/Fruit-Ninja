using System;
using Blocks.BlockServices.CuttingSystem.Implementations;
using Managers;
using Models.DependencyInjection;
using UI.Game;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Factories
{
    [CreateAssetMenu(fileName = "ComboIncreaseSetting", menuName = "CuttingServicesSettings/ComboIncreaseSetting")]
    public class ComboIncreaseFactory : CuttingServiceFactory
    {
        [SerializeField] private bool changeComboPosition;
        
        public override Type CuttingServiceType => typeof(ComboIncrease);

        public override ICuttingService GetService()
        {
            var comboManager = ProjectContext.Instance.GetService<ComboManager>();
            var comboRenderer = ProjectContext.Instance.GetService<ComboRenderer>();

            var implementation = new ComboIncrease(comboManager, comboRenderer);
            implementation.Init(changeComboPosition);
            return implementation;
        }
    }
}