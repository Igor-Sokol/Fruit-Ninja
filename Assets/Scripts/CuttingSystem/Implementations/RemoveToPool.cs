using BlockComponents;
using BlockStackSystem;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class RemoveToPool : ICuttingService
    {
        private readonly BlockContainer _playingFieldBlocks;
        private readonly BlockStackGenerator _blockStackGenerator;

        public RemoveToPool(BlockContainer playingFieldBlocks, BlockStackGenerator blockStackGenerator)
        {
            _playingFieldBlocks = playingFieldBlocks;
            _blockStackGenerator = blockStackGenerator;
        }
        
        public ServiceCallbackAction Cut(Block block, Vector2 bladeVector)
        {
            _playingFieldBlocks.RemoveBlock(block);
            _blockStackGenerator.ReturnBlock(block);

            return ServiceCallbackAction.None;
        }
    }
}