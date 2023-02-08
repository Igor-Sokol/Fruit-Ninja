using BlockComponents;
using Managers;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class TimeSlower : ICuttingService
    {
        private readonly TimeScaleManager _timeScaleManager;
        private float _scale;
        private float _time;

        public void Init(float scale, float time)
        {
            _scale = scale;
            _time = time;
        }

        public TimeSlower(TimeScaleManager timeScaleManager)
        {
            _timeScaleManager = timeScaleManager;
        }
        
        public void Cut(Block block, Vector2 bladeVector)
        {
            _timeScaleManager.SetTimeScale(_scale, _time);
        }
    }
}