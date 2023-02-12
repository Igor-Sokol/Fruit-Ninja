using System;

namespace TimerSystem
{
    public class TimerCounter
    {
        private float _secondsLeft;
        private bool _isWorking;

        public bool IsWorking => _isWorking;
        public event Action OnBegin;
        public event Action OnUpdate;
        public event Action OnComplete;

        public void Start(float seconds)
        {
            _secondsLeft = seconds;
            _isWorking = true;
            OnBegin?.Invoke();
        }
    
        private void Reset()
        {
            _isWorking = false;
            OnBegin = null;
            OnUpdate = null;
            OnComplete = null;
        }
    
        public void UpdateCounter(float deltaTime)
        {
            if (!_isWorking) return;

            _secondsLeft -= deltaTime;
            OnUpdate?.Invoke();
            
            if (_secondsLeft <= 0)
            {
                OnComplete?.Invoke();
                Reset();
            }
        }
    }
}