using System;
using Blocks.BlockServices.PlayingFieldServices.Implementations;
using Blocks.BlockStackSystem;
using Models.DependencyInjection;
using UnityEngine;

namespace Blocks.BlockServices.PlayingFieldServices.Factories
{
    [CreateAssetMenu(fileName = "Mimic", menuName = "PlayingFieldService/Mimic")]
    public class MimicFactory : PlayingFieldServiceFactory
    {
        [SerializeField] private BlockStackSetting[] stackSettings;
        [SerializeField] private float time;

        public override Type CuttingServiceType => typeof(Mimic);

        public override IPlayingFieldService GetService()
        {
            var stackGenerator = ProjectContext.Instance.GetService<BlockStackGenerator>();

            var implementation = new Mimic(stackGenerator);
            implementation.Init(stackSettings, time);
            return implementation;
        }
    }
}