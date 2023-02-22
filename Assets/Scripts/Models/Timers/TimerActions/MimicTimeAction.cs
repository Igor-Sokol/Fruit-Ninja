using System.Linq;
using Blocks.BlockComponents;
using Blocks.BlockServices.BeyondZoneSystem;
using Blocks.BlockServices.CuttingSystem;
using Blocks.BlockServices.PlayingFieldServices;
using Blocks.BlockServices.PlayingFieldServices.Implementations;
using Blocks.BlockStackSystem;
using Models.Timers.TimerSystem;
using UnityEngine;

namespace Models.Timers.TimerActions
{
    public class MimicTimeAction : ITimerAction
    {
        private readonly BlockStackGenerator _stackGenerator;
        private readonly BlockStackSetting[] _stackSettings;
        private readonly Mimic _mimicService;
        private Block _block;

        private ICuttingService[] _cuttingServices;
        private IBeyondService[] _beyondServices;
        private IPlayingFieldService[] _playingFieldServices;
        
        public float TimeLeft { get; private set; }

        public MimicTimeAction(BlockStackGenerator stackGenerator, BlockStackSetting[] stackSettings,
            Mimic mimicService)
        {
            _stackGenerator = stackGenerator;
            _stackSettings = stackSettings;
            _mimicService = mimicService;
        }

        public bool TryInitBlock(Block block)
        {
            if (!_block)
            {
                _block = block;
                
                _cuttingServices = block.CuttingManager.CuttingServices.ToArray();
                _beyondServices = block.BeyondServices.ToArray();
                _playingFieldServices = block.PlayingFieldServiceManager.Services.ToArray();

                return true;
            }

            return false;
        }

        public void OnBegin(float secondsLeft)
        {
            TimeLeft = secondsLeft;
            
            var newBlock = _stackGenerator.GetBlocks(_stackSettings, 1).First();

            _block.SetUp(newBlock.BlockSetting);

            foreach (var service in _cuttingServices)
            {
                _block.CuttingManager.AddService(service);
            }
            
            foreach (var service in _beyondServices)
            {
                _block.BeyondServices.Add(service);
            }
            
            foreach (var service in _playingFieldServices)
            {
                _block.PlayingFieldServiceManager.AddService(service);
            }

            _stackGenerator.ReturnBlock(newBlock);
        }

        public void OnUpdate(float secondsLeft)
        {
            TimeLeft = secondsLeft;
        }

        public void OnComplete()
        {
            TimeLeft = 0f;
            _mimicService.Enabled = true;
        }
    }
}