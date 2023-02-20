using BlockComponents;
using PlayingFieldServices;
using PlayingFieldServices.Settings;
using TimerActions;
using TimerSystem;
using UnityEngine;

namespace CuttingSystem.Implementations
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