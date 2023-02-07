using System;
using CuttingSystem.Fabrics;
using CuttingSystem.Implementations;
using Particles;
using UnityEngine;

namespace CuttingSystem.Settings
{
    [CreateAssetMenu(fileName = "ScoreIncreaseSetting", menuName = "CuttingServicesSettings/ScoreIncreaseSetting")]
    public class ScoreIncreaseSetting : CuttingServiceSetting
    {
        [SerializeField] private int score;
        [SerializeField] private TextParticle textParticle;
        
        public override Type CuttingServiceType => typeof(ScoreIncrease);
        public override Type CuttingServiceFabricType => typeof(ScoreIncreaseFabric);
        
        public override ICuttingService GetService()
        {
            var fabric = CuttingServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as ScoreIncrease;
            if (implementation == null) return null;
            
            implementation.Init(score, textParticle);
            return implementation;
        }
    }
}