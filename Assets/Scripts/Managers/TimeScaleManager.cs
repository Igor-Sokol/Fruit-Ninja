using System;
using System.Collections;
using UnityEngine;

namespace Managers
{
    public class TimeScaleManager : MonoBehaviour
    {
        private Coroutine _scaleTimerHandler; 
        private float _timer;

        [SerializeField] private float defaultScale;

        public float CurrentScale { get; private set; }
        public float DefaultScale => defaultScale;

        private void Awake()
        {
            CurrentScale = defaultScale;
        }

        public void SetTimeScale(float scale)
        {
            if (scale < 0) return;

            if (_scaleTimerHandler != null)
            {
                StopCoroutine(_scaleTimerHandler);
            }

            CurrentScale = scale;
        }
        
        public void SetTimeScale(float scale, float seconds)
        {
            if (scale < 0) return;

            CurrentScale = scale;
            _timer = seconds;
            
            _scaleTimerHandler ??= StartCoroutine(ScaleTimer());
        }

        private IEnumerator ScaleTimer()
        {
            while (_timer > 0)
            {
                _timer -= Time.unscaledDeltaTime;
                yield return null;
            }

            CurrentScale = defaultScale;
            _scaleTimerHandler = null;
        }
    }
}