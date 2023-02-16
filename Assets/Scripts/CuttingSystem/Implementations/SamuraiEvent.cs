using BlockComponents;
using BlockConfiguration;
using BlockStackSystem;
using DifficultySystem;
using TimerActions;
using TimerSystem;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class SamuraiEvent : ICuttingService
    {
        private readonly BlockStackGenerator _blockStackGenerator;
        private readonly SamuraiEventRenderer _samuraiEventRenderer;
        private IDifficultySetting _difficultySetting;
        private BlockStackSetting[] _stackSettings;
        private float _time;

        public void Init(IDifficultySetting difficultySetting, BlockStackSetting[] stackSettings, float time)
        {
            _difficultySetting = difficultySetting;
            _stackSettings = stackSettings;
            _time = time;
        }
        
        public SamuraiEvent(BlockStackGenerator blockStackGenerator, SamuraiEventRenderer samuraiEventRenderer)
        {
            _blockStackGenerator = blockStackGenerator;
            _samuraiEventRenderer = samuraiEventRenderer;
        }

        public ServiceCallbackAction Cut(Block block, Vector2 bladeVector)
        {
            var samuraiTimeAction =
                new SamuraiTimeAction(_blockStackGenerator, _difficultySetting, _stackSettings, _samuraiEventRenderer);
            
            Timer.Instance.AddTimer(samuraiTimeAction, _time);

            return ServiceCallbackAction.None;
        }
    }
}