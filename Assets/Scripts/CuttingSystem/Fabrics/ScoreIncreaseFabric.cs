using CuttingSystem.Implementations;
using ScoreSystem;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class ScoreIncreaseFabric : CuttingServiceFabric
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Transform canvas;

        public override ICuttingService Create()
        {
            return new ScoreIncrease(scoreManager, canvas);
        }
    }
}