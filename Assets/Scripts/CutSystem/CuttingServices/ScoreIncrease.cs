using BlockComponents;
using Particles;
using ScoreSystem;
using UnityEngine;

namespace CutSystem.CuttingServices
{
    public class ScoreIncrease : CuttingService
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Transform canvas;
        [SerializeField] private TextParticle particle;
        [SerializeField] private int[] dropScores;
        
        public override void Cut(Block block, Vector2 bladeVector)
        {
            var score = dropScores[Random.Range(0, dropScores.Length)];
            scoreManager.AddScore(score);
            var textParticle = Instantiate(particle, block.transform.position, Quaternion.identity, canvas);
            textParticle.SetText(score.ToString());
        }
    }
}