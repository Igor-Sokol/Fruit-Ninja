using BlockComponents;
using Managers;
using TimerActions;
using TimerSystem;
using UI;
using UnityEngine;

namespace CuttingSystem.Implementations
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
        
        public ServiceCallbackAction Cut(Block block, Vector2 bladeVector)
        {
            Timer.Instance.AddTimer(new FrozenTimeAction(_timeScaleManager, _filterRenderer, _scale, _time), _time);

            return ServiceCallbackAction.None;
        }
    }
}