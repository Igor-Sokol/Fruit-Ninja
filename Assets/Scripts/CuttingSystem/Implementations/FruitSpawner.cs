using System.Collections;
using System.Collections.Generic;
using BlockComponents;
using BlockStackSystem;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class FruitSpawner : ICuttingService
    {
        private readonly BlockContainer _playingFieldContainer;
        private readonly BlockStackGenerator _blockStackGenerator;
        private BlockStackSetting[] _blockStackSettings;
        private int _count;
        private float _force;
        private float _spawnRangeOffset;
        private float _uncutTime;

        public void Init(BlockStackSetting[] blockStackSettings, int count, float force, float spawnRangeOffset, float uncutTime)
        {
            _blockStackSettings = blockStackSettings;
            _count = count;
            _force = force;
            _spawnRangeOffset = spawnRangeOffset;
            _uncutTime = uncutTime;
        }
        
        public FruitSpawner(BlockContainer playingFieldContainer, BlockStackGenerator blockStackGenerator)
        {
            _playingFieldContainer = playingFieldContainer;
            _blockStackGenerator = blockStackGenerator;
        }
        
        public ServiceCallbackAction Cut(Block block, Vector2 bladeVector)
        {
            List<Block> newBlocks = new List<Block>(_blockStackGenerator.GetBlocks(_blockStackSettings, _count));

            foreach (var newBlock in newBlocks)
            {
                newBlock.CuttingManager.SwitchState(false, _uncutTime);

                newBlock.transform.position = block.transform.position + (Vector3)(Random.insideUnitCircle * _spawnRangeOffset);

                var direction = ((newBlock.transform.position - block.transform.position).normalized + Vector3.up).normalized;
                newBlock.BlockPhysic.SetVelocity(block.BlockPhysic.Velocity + direction * _force);
                _playingFieldContainer.AddBlock(newBlock);
            }

            return ServiceCallbackAction.None;
        }
    }
}