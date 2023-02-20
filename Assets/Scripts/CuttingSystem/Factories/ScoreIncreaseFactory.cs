using CuttingSystem.Implementations;
using Managers;
using ScoreSystem;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class ScoreIncreaseFactory : CuttingServiceFactory
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Transform canvas;
        [SerializeField] private ComboManager comboManager;

        public override ICuttingService Create()
        {
            return new ScoreIncrease(scoreManager, canvas, comboManager);
        }
    }
}