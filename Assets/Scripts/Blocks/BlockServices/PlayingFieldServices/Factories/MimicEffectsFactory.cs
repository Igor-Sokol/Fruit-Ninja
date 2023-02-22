using System;
using Blocks.BlockServices.PlayingFieldServices.Implementations;
using UnityEngine;

namespace Blocks.BlockServices.PlayingFieldServices.Factories
{
    [CreateAssetMenu(fileName = "MimicEffects", menuName = "PlayingFieldService/MimicEffects")]
    public class MimicEffectsFactory : PlayingFieldServiceFactory
    {
        [SerializeField] private ParticleSystem mimicEffectPrefab;
        [SerializeField] private ParticleSystem mimicChangeEffectPrefab;
        [SerializeField] private float changingTime;

        public override Type CuttingServiceType => typeof(MimicEffects);
        
        public override IPlayingFieldService GetService()
        {
            var mimicEffects = new MimicEffects();
            mimicEffects.Init(mimicEffectPrefab, mimicChangeEffectPrefab, changingTime);

            return mimicEffects;
        }
    }
}