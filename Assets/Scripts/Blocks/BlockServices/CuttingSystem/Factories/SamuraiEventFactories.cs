using System;
using BlockStackSystem;
using CuttingSystem.Implementations;
using DependencyInjection;
using DifficultySystem.Implementations;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "SamuraiEvent", menuName = "CuttingServicesSettings/SamuraiEvent")]
    public class SamuraiEventFactories : CuttingServiceFactory
    {
        public override Type CuttingServiceType => typeof(SamuraiEvent);

        [SerializeField] private StaticSetting difficultySetting;
        [SerializeField] private BlockStackSetting[] stackSettings;
        [SerializeField] private float time;
        
        public override ICuttingService GetService()
        {
            var blockStackGenerator = ProjectContext.Instance.GetService<BlockStackGenerator>();
            var samuraiEventRenderer = ProjectContext.Instance.GetService<SamuraiEventRenderer>();

            var implementation = new SamuraiEvent(blockStackGenerator, samuraiEventRenderer);
            implementation.Init(difficultySetting, stackSettings, time);
            return implementation;
        }
    }
}