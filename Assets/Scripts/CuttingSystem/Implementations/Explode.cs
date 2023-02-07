using System.Linq;
using BlockComponents;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class Explode : ICuttingService
    {
        private readonly BlockContainer _playingFieldBlocks;
        private readonly BlockPool _blockPool;
        private float _range;
        private float _force;

        public void Init(float range, float force)
        {
            _range = range;
            _force = force;
        }
        
        public Explode(BlockContainer playingFieldBlocks, BlockPool blockPool)
        {
            _playingFieldBlocks = playingFieldBlocks;
            _blockPool = blockPool;
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
            _blockPool.ReturnBlock(block);
        }
    }
}