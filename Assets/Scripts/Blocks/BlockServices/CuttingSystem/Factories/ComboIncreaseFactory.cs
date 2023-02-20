using System;
using CuttingSystem.Implementations;
using DependencyInjection;
using Managers;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Settings
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