namespace TimerSystem
{
    public interface ITimerAction
    {
        void OnBegin();
        void OnUpdate();
        void OnComplete();
    }
}