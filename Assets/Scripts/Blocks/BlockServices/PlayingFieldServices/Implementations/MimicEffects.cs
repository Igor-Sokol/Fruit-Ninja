using System.Linq;
using Blocks.BlockComponents;
using Models.Timers.TimerActions;
using UnityEngine;

namespace Blocks.BlockServices.PlayingFieldServices.Implementations
{
    public class MimicEffects : IPlayingFieldService
    {
        private bool _initialized;
        private Block _block;
        private Mimic _mimic;
        private MimicTimeAction _mimicTimeAction;
        private ParticleSystem _mimicEffect;
        private ParticleSystem _mimicChangeEffect;
        private float _changingTime;

        public void Init(ParticleSystem mimicEffectPrefab,
            ParticleSystem mimicChangeEffectPrefab, float changingTime)
        {
            _mimicEffect = Object.Instantiate(mimicEffectPrefab);
            _mimicChangeEffect = Object.Instantiate(mimicChangeEffectPrefab);
            _changingTime = changingTime;
        }
        
        public void OnPlayingField(Block block)
        {
            if (!_initialized)
            {
                _block = block;
                
                _mimic = (Mimic)_block.PlayingFieldServiceManager.Services
                    .First(s => s.GetType() == typeof(Mimic));

                _mimicTimeAction = _mimic.MimicTimeAction;
            }

            if (_mimicTimeAction.TimeLeft >= _changingTime && _mimicChangeEffect.isPlaying)
            {
                _mimicChangeEffect.Stop();
            }
            else if (_mimicChangeEffect.isStopped)
            {
                _mimicChangeEffect.Play();
            }
            
            _mimicEffect.transform.position = block.transform.position;
            _mimicChangeEffect.transform.position = block.transform.position;
        }

        public void DisableEffects()
        {
            Object.Destroy(_mimicEffect.gameObject);
            Object.Destroy(_mimicChangeEffect.gameObject);
        }
    }
}