using BlockComponents;
using PlayingFieldServices.Settings;
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
            block.BlockPhysic.enabled = false;

            var magnetService = _magnetFieldSettings.GetService();
            block.PlayingFieldServiceManager.AddService(magnetService);
            var particleInstance = Object.Instantiate(_particle, block.transform.position, Quaternion.identity);
            
            Timer.Instance.AddTimer(_seconds, () =>
            {
                block.BlockPhysic.enabled = true;
                block.PlayingFieldServiceManager.RemoveService(magnetService);
                Object.Destroy(particleInstance.gameObject);
            });

            return ServiceCallbackAction.Delete;
        }
    }
}