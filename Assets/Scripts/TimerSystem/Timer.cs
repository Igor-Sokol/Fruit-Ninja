using System;
using System.Collections.Generic;
using UnityEngine;

namespace TimerSystem
{
    public class Timer : Singleton<Timer>
    {
        private List<TimerCounter> _timerCounters;

        private void Awake()
        {
            _timerCounters = new List<TimerCounter>();
        }

        private void Update()
        {
            foreach (var timerCounter in _timerCounters)
            {
                timerCounter.UpdateCounter(Time.deltaTime);
            }
        }

        public void AddTimer(ITimerAction timerAction, float seconds)
        {
            AddTimer(seconds, timerAction.OnComplete, timerAction.OnBegin, timerAction.OnUpdate);
        }
        
        public void AddTimer(float seconds, Action onComplete, Action onBegin = null, Action onUpdate = null)
        {
            TimerCounter counter = GetTimerCounter();
            counter.OnBegin += onBegin;
            counter.OnUpdate += onUpdate;
            counter.OnComplete += onComplete;
            counter.Start(seconds);
        }

        private TimerCounter GetTimerCounter()
        {
            TimerCounter counter = null;

            foreach (var timerCounter in _timerCounters)
            {
                if (!timerCounter.IsWorking)
                {
                    counter = timerCounter;
                }
            }

            if (counter is null)
            {
                counter = AddTimerCounter();
            }

            return counter;
        }
    
        private TimerCounter AddTimerCounter()
        {
            TimerCounter counter = new TimerCounter();
            _timerCounters.Add(counter);

            return counter;
        }
    }
}