using Blocks.BlockComponents;
using Blocks.BlockServices.PlayingFieldServices;
using Blocks.BlockServices.PlayingFieldServices.Factories;
using Models.Timers.TimerActions;
using Models.Timers.TimerSystem;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Implementations
{
    public class MakeMagnetField : ICuttingService
    {
        private MagnetFieldFactories _magnetFieldFactories;
        private ParticleSystem _particle;
        private float _seconds;

        public void Init(MagnetFieldFactories magnetFieldFactories, ParticleSystem particle, float seconds)
        {
            _magnetFieldFactories = magnetFieldFactories;
            _particle = particle;
            _seconds = seconds;
        }
        
        public void Cut(Block block, Vector2 bladeVector)
        {
            IPlayingFieldService[] playingFieldServices = new[] { _magnetFieldFactories.GetService() };
            ParticleSystem[] particles = new[] { _particle };
            
            Timer.Instance.AddTimer(new InvulnerableTimeAction(block, playingFieldServices, particles), _seconds);

            block.CuttingManager.RemoveService(this);
        }
    }
}