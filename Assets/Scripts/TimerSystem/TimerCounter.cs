using System;

namespace TimerSystem
{
    public class TimerCounter
    {
        private float _secondsLeft;
        private Action _onTime;
        private bool _isWorking;

        public bool IsWorking => _isWorking;
    
        public event Action OnTime
        {
            add => _onTime = (Action)Delegate.Combine(_onTime, value);
            remove => _onTime = (Action)Delegate.Remove(_onTime, value);
        }

        public void Start(float seconds)
        {
            _secondsLeft = seconds;
            _isWorking = true;
        }
    
        private void Reset()
        {
            _isWorking = false;
            _onTime = null;
        }
    
        public void UpdateCounter(float deltaTime)
        {
            if (!_isWorking) return;

            _secondsLeft -= deltaTime;

            if (_secondsLeft <= 0)
            {
                _onTime?.Invoke();
                Reset();
            }
        }
    }
}