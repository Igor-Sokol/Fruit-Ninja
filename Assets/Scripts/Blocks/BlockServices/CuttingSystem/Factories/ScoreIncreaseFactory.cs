using System;
using CuttingSystem.Implementations;
using DependencyInjection;
using Managers;
using Particles;
using ScoreSystem;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "ScoreIncreaseSetting", menuName = "CuttingServicesSettings/ScoreIncreaseSetting")]
    public class ScoreIncreaseFactory : CuttingServiceFactory
    {
        [SerializeField] private int score;
        [SerializeField] private TextParticle textParticle;
        [SerializeField] private float randomSpawnOffsetMultiply;
        
        public override Type CuttingServiceType => typeof(ScoreIncrease);

        public override ICuttingService GetService()
        {
            var scoreManager = ProjectContext.Instance.GetService<ScoreManager>();
            var canvas = ProjectContext.Instance.GetService<Canvas>();
            var comboManager = ProjectContext.Instance.GetService<ComboManager>();

            var implementation = new ScoreIncrease(scoreManager, canvas.transform, comboManager);
            implementation.Init(score, textParticle, randomSpawnOffsetMultiply);
            return implementation;
        }
    }
}