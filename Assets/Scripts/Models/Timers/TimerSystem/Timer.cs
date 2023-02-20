using System.Collections.Generic;
using Models.Singleton;
using UnityEngine;

namespace Models.Timers.TimerSystem
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
            TimerCounter counter = GetTimerCounter();
            counter.Start(timerAction, seconds);
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