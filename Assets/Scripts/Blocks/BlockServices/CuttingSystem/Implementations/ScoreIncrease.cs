using Blocks.BlockComponents;
using Extensions.Particles;
using GameSystems.ScoreSystem;
using Managers;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Implementations
{
    public class ScoreIncrease : ICuttingService
    {
        private readonly ScoreManager _scoreManager;
        private readonly Transform _canvas;
        private readonly ComboManager _comboManager;
        private TextParticle _particle;
        private int _score;
        private float _randomSpawnScale;

        public ScoreIncrease(ScoreManager scoreManager, Transform canvas, ComboManager comboManager)
        {
            _scoreManager = scoreManager;
            _canvas = canvas;
            _comboManager = comboManager;
        }

        public void Init(int score, TextParticle particle, float randomSpawnScale)
        {
            _score = score;
            _particle = particle;
            _randomSpawnScale = randomSpawnScale;
        }

        public void Cut(Block block, Vector2 bladeVector)
        {
            var actualScore = _score * (_comboManager.CurrentCombo > 0 ? _comboManager.CurrentCombo : 1);

            _scoreManager.AddScore(actualScore);
            var textParticle = Object.Instantiate(_particle, block.transform.position + (Vector3)(Random.insideUnitCircle * _randomSpawnScale), Quaternion.identity, _canvas);
            textParticle.SetText(actualScore.ToString());
        }
    }
}