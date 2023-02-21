namespace Models.Timers.TimerSystem
{
    public class TimerCounter
    {
        private bool _isWorking;
        private ITimerAction _timerAction;
        private float _secondsLeft;

        public bool IsWorking => _isWorking;
        public ITimerAction TimerAction => _timerAction;
        public float SecondsLeft => _secondsLeft;

        public void Start(ITimerAction timerAction, float seconds)
        {
            _isWorking = true;
            _timerAction = timerAction;
            _secondsLeft = seconds;
            _timerAction.OnBegin(SecondsLeft);
        }

        public void ForceEnd()
        {
            _timerAction.OnComplete();
            Reset();
        }
        
        private void Reset()
        {
            _isWorking = false;
            _timerAction = null;
        }
    
        public void UpdateCounter(float deltaTime)
        {
            if (!_isWorking) return;

            _secondsLeft -= deltaTime;
            _timerAction.OnUpdate(SecondsLeft);
            
            if (_secondsLeft <= 0)
            {
                _timerAction.OnComplete();
                Reset();
            }
        }
    }
}