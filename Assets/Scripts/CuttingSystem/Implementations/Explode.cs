using System.Linq;
using BlockComponents;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class Explode : ICuttingService
    {
        private readonly BlockContainer _playingFieldBlocks;
        private readonly BlockStackGenerator _blockStackGenerator;
        private float _range;
        private float _force;

        public void Init(float range, float force)
        {
            _range = range;
            _force = force;
        }
        
        public Explode(BlockContainer playingFieldBlocks, BlockStackGenerator blockStackGenerator)
        {
            _playingFieldBlocks = playingFieldBlocks;
            _blockStackGenerator = blockStackGenerator;
        }
        
        public void Cut(Block block, Vector2 bladeVector)
        {
            var targets = _playingFieldBlocks.Blocks.Where(b =>
                (b.transform.position - block.transform.position).magnitude <= _range);
            
            foreach (var target in targets)
            {
                var vector = target.transform.position - block.transform.position;
                target.BlockPhysic.AddForce(vector.normalized, _force * (1f - vector.magnitude / _range));
            }
            
            _playingFieldBlocks.RemoveBlock(block);
            _blockStackGenerator.ReturnBlock(block);
        }
    }
}