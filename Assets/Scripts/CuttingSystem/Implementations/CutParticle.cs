using BlockComponents;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class CutParticle : ICuttingService
    {
        private ParticleSystem _cuttingParticle;

        public void Init(ParticleSystem cuttingParticle)
        {
            _cuttingParticle = cuttingParticle;
        }
        
        public void Cut(Block block, Vector2 bladeVector)
        {
            var blotParticle = Object.Instantiate(_cuttingParticle, block.transform.position, Quaternion.identity);
            blotParticle.transform.localScale = block.transform.localScale;
        }
    }
}