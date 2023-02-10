using System.Linq;
using BlockComponents;
using BlockConfiguration;
using PlayingFieldComponents;
using UnityEngine;

namespace PlayingFieldServices.Implementations
{
    public class MagnetField : IPlayingFieldService
    {
        private readonly BlockContainer _playingField;
        private BlockSettingObject[] _influenceExclusions;
        private float _force;

        public void Init(float force, BlockSettingObject[] influenceExclusions)
        {
            _force = force;
            _influenceExclusions = influenceExclusions;
        }

        public MagnetField(BlockContainer playingField)
        {
            _playingField = playingField;
        }
        
        public void OnPlayingField(Block block)
        {
            foreach (var fieldBlock in _playingField.Blocks)
            {
                if (!_influenceExclusions.Any(c => c.BlockSetting.Equals(fieldBlock.BlockSetting)))
                {
                    var direction = block.transform.position - fieldBlock.transform.position;
                    fieldBlock.BlockPhysic.SetForce(direction.normalized, _force);
                }
            }
        }
    }
}