using Blocks.BlockComponents;
using Blocks.BlockStackSystem;
using Models.Timers.TimerActions;
using Models.Timers.TimerSystem;
using UnityEngine;

namespace Blocks.BlockServices.PlayingFieldServices.Implementations
{
    public class Mimic : IPlayingFieldService
    {
        private readonly BlockStackGenerator _stackGenerator;
        private MimicTimeAction _mimicTimeAction;
        private BlockStackSetting[] _stackSettings;
        private float _time;

        public bool Enabled { get; set; }
        public MimicTimeAction MimicTimeAction => _mimicTimeAction;

        public void Init(BlockStackSetting[] blockStackSetting, float time)
        {
            _stackSettings = blockStackSetting;
            _time = time;

            _mimicTimeAction = new MimicTimeAction(_stackGenerator, _stackSettings, this);
        }
        
        public Mimic(BlockStackGenerator blockStackGenerator)
        {
            _stackGenerator = blockStackGenerator;
            Enabled = true;
        }
        
        public void OnPlayingField(Block block)
        {
            if (Enabled)
            {
                _mimicTimeAction.TryInitBlock(block);
                Timer.Instance.AddTimer(_mimicTimeAction, _time);
                Enabled = false;
            }
        }
    }
}