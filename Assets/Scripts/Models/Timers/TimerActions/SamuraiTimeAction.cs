using BlockStackSystem;
using DifficultySystem;
using TimerSystem;
using UI.Game;
using UnityEngine;

namespace TimerActions
{
    public class SamuraiTimeAction : ITimerAction
    {
        private readonly BlockStackGenerator _blockStackGenerator;
        private readonly IDifficultySetting _difficultySetting;
        private readonly BlockStackSetting[] _stackSettings;
        private readonly SamuraiEventRenderer _samuraiEventRenderer;

        public SamuraiTimeAction(BlockStackGenerator blockStackGenerator, IDifficultySetting difficultySetting,
            BlockStackSetting[] stackSettings, SamuraiEventRenderer samuraiEventRenderer)
        {
            _blockStackGenerator = blockStackGenerator;
            _difficultySetting = difficultySetting;
            _stackSettings = stackSettings;
            _samuraiEventRenderer = samuraiEventRenderer;
        }

        public void OnBegin(float secondsLeft)
        {
            _blockStackGenerator.SetDifficult(_difficultySetting);
            _blockStackGenerator.SetStackSettings(_stackSettings);
            
            _samuraiEventRenderer.TimerRenderer.SetValue((int)secondsLeft);
            _samuraiEventRenderer.Enable();
        }

        public void OnUpdate(float secondsLeft)
        {
            _samuraiEventRenderer.TimerRenderer.SetValue(Mathf.CeilToInt(secondsLeft));
        }

        public void OnComplete()
        {
            _blockStackGenerator.SetDifficult(_blockStackGenerator.DefaultDifficultySetting);
            _blockStackGenerator.SetStackSettings(_blockStackGenerator.DefaultStackSettings);
            
            _samuraiEventRenderer.TimerRenderer.SetValue(0);
            _samuraiEventRenderer.Disable();
        }
    }
}