using Blocks.BlockComponents;
using Managers;
using Models.Timers.TimerActions;
using Models.Timers.TimerSystem;
using UI;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Implementations
{
    public class TimeSlower : ICuttingService
    {
        private readonly TimeScaleManager _timeScaleManager;
        private readonly FilterRenderer _filterRenderer;
        private float _scale;
        private float _time;

        public void Init(float scale, float time)
        {
            _scale = scale;
            _time = time;
        }

        public TimeSlower(TimeScaleManager timeScaleManager, FilterRenderer filterRenderer)
        {
            _timeScaleManager = timeScaleManager;
            _filterRenderer = filterRenderer;
        }
        
        public void Cut(Block block, Vector2 bladeVector)
        {
            Timer.Instance.AddTimer(new FrozenTimeAction(_timeScaleManager, _filterRenderer, _scale, _time), _time);
        }
    }
}