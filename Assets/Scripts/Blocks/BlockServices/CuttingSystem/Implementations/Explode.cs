using System.Linq;
using Blocks.BlockComponents;
using PlayingFieldComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Implementations
{
    public class Explode : ICuttingService
    {
        private readonly BlockContainer _playingFieldBlocks;
        private float _range;
        private float _force;

        public void Init(float range, float force)
        {
            _range = range;
            _force = force;
        }
        
        public Explode(BlockContainer playingFieldBlocks)
        {
            _playingFieldBlocks = playingFieldBlocks;
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
        }
    }
}