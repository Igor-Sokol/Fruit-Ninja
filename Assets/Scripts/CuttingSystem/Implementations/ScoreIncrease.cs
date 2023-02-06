using BlockComponents;
using Particles;
using ScoreSystem;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class ScoreIncrease : ICuttingService
    {
        private readonly ScoreManager _scoreManager;
        private readonly Transform _canvas;
        private TextParticle _particle;
        private int _score;

        public ScoreIncrease(ScoreManager scoreManager, Transform canvas)
        {
            _scoreManager = scoreManager;
            _canvas = canvas;
        }

        public void Init(int score, TextParticle particle)
        {
            _score = score;
            _particle = particle;
        }

        public void Cut(Block block, Vector2 bladeVector)
        {
            _scoreManager.AddScore(_score);
            var textParticle = Object.Instantiate(_particle, block.transform.position, Quaternion.identity, _canvas);
            textParticle.SetText(_score.ToString());
        }
    }
}