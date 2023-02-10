using PlayingFieldComponents;
using PlayingFieldServices.Implementations;
using UnityEngine;

namespace PlayingFieldServices.Fabrics
{
    public class MagnetFieldFabric : PlayingFieldServiceFabric
    {
        [SerializeField] private BlockContainer playingField;
        
        public override IPlayingFieldService Create()
        {
            return new MagnetField(playingField);
        }
    }
}