using BlockComponents;
using Managers;
using Particles;
using ScoreSystem;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class ScoreIncrease : ICuttingService
    {
        private readonly ScoreManager _scoreManager;
        private readonly Transform _canvas;
        private readonly ComboManager _comboManager;
        private TextParticle _particle;
        private int _score;

        public ScoreIncrease(ScoreManager scoreManager, Transform canvas, ComboManager comboManager)
        {
            _scoreManager = scoreManager;
            _canvas = canvas;
            _comboManager = comboManager;
        }

        public void Init(int score, TextParticle particle)
        {
            _score = score;
            _particle = particle;
        }

        public void Cut(Block block, Vector2 bladeVector)
        {
            var actualScore = _score * (_comboManager.CurrentCombo > 0 ? _comboManager.CurrentCombo : 1);

            _scoreManager.AddScore(actualScore);
            var textParticle = Object.Instantiate(_particle, block.transform.position, Quaternion.identity, _canvas);
            textParticle.SetText(actualScore.ToString());
        }
    }
}