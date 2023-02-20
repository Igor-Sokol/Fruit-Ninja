namespace Models.Timers.TimerSystem
{
    public interface ITimerAction
    {
        void OnBegin(float secondsLeft);
        void OnUpdate(float secondsLeft);
        void OnComplete();
    }
}