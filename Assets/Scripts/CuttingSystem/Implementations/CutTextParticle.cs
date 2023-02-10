using BlockComponents;
using Particles;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class CutTextParticle : ICuttingService
    {
        private readonly Transform _canvas;
        private TextParticle _particle;
        private string _text;

        public void Init(TextParticle particle, string text)
        {
            _particle = particle;
            _text = text;
        }
        
        public CutTextParticle(Transform canvas)
        {
            _canvas = canvas;
        }
        
        public ServiceCallbackAction Cut(Block block, Vector2 bladeVector)
        {
            var textParticle = Object.Instantiate(_particle, block.transform.position, Quaternion.identity, _canvas);
            textParticle.SetText(_text);

            return ServiceCallbackAction.None;
        }
    }
}