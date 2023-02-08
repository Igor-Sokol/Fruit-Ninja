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
        private float _spawnOffset;

        public void Init(BlockStackSetting[] blockStackSettings, int count, float force, float spawnOffset)
        {
            _blockStackSettings = blockStackSettings;
            _count = count;
            _force = force;
            _spawnOffset = spawnOffset;
        }
        
        public FruitSpawner(BlockContainer playingFieldContainer, BlockStackGenerator blockStackGenerator)
        {
            _playingFieldContainer = playingFieldContainer;
            _blockStackGenerator = blockStackGenerator;
        }
        
        public void Cut(Block block, Vector2 bladeVector)
        {
            List<Block> newBlocks = new List<Block>(_blockStackGenerator.GetBlocks(_blockStackSettings, _count));

            for (int i = 0; i < newBlocks.Count; i++)
            {
                var newBlock = newBlocks[i];
                newBlock.transform.position = block.transform.position + (Vector3)Random.insideUnitCircle * _spawnOffset;
                newBlock.BlockPhysic.SetForce(block.BlockPhysic.Velocity.normalized, _force);
                _playingFieldContainer.AddBlock(newBlock);
            }
        }
    }
}