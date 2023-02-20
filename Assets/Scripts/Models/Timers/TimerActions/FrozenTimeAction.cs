using Managers;
using TimerSystem;
using UI;

namespace TimerActions
{
    public class FrozenTimeAction : ITimerAction
    {
        private readonly TimeScaleManager _timeScaleManager;
        private readonly FilterRenderer _filterRenderer;
        private readonly float _scale;
        private readonly float _time;

        public FrozenTimeAction(TimeScaleManager timeScaleManager, FilterRenderer filterRenderer, float scale,
            float time)
        {
            _timeScaleManager = timeScaleManager;
            _filterRenderer = filterRenderer;
            _scale = scale;
            _time = time;
        }
        
        public void OnBegin(float secondsLeft)
        {
            _timeScaleManager.SetTimeScale(_scale);
            _filterRenderer.Show(_time);
        }

        public void OnUpdate(float secondsLeft)
        {
        }

        public void OnComplete()
        {
            _timeScaleManager.SetTimeScale(_timeScaleManager.DefaultScale);
        }
    }
}