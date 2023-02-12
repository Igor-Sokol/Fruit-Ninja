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
        private MagnetFieldSettings _magnetFieldSettings;
        private ParticleSystem _particle;
        private float _seconds;

        public void Init(MagnetFieldSettings magnetFieldSettings, ParticleSystem particle, float seconds)
        {
            _magnetFieldSettings = magnetFieldSettings;
            _particle = particle;
            _seconds = seconds;
        }
        
        public ServiceCallbackAction Cut(Block block, Vector2 bladeVector)
        {
            IPlayingFieldService[] playingFieldServices = new[] { _magnetFieldSettings.GetService() };
            ParticleSystem[] particles = new[] { _particle };
            
            Timer.Instance.AddTimer(new InvulnerableTimeAction(block, playingFieldServices, particles), _seconds);

            return ServiceCallbackAction.Delete;
        }
    }
}