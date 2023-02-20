using CuttingSystem;
using TimerSystem;

namespace TimerActions
{
    public class UncutTimeAction : ITimerAction
    {
        private readonly CuttingManager _cuttingManager;

        public UncutTimeAction(CuttingManager cuttingManager)
        {
            _cuttingManager = cuttingManager;
        }
        
        public void OnBegin(float secondsLeft)
        {
            _cuttingManager.SwitchState(false);
        }

        public void OnUpdate(float secondsLeft)
        {
        }

        public void OnComplete()
        {
            _cuttingManager.SwitchState(true);
        }
    }
}