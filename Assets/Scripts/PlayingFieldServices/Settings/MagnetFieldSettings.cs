using System;
using BlockConfiguration;
using PlayingFieldServices.Fabrics;
using PlayingFieldServices.Implementations;
using UnityEngine;

namespace PlayingFieldServices.Settings
{
    [CreateAssetMenu(fileName = "MagnetField", menuName = "PlayingFieldService/MagnetField")]
    public class MagnetFieldSettings : PlayingFieldServiceSetting
    {
        [SerializeField] private float force;
        [SerializeField] private BlockSettingObject[] influenceExclusions;
        
        public override Type CuttingServiceType => typeof(MagnetField);
        public override Type CuttingServiceFabricType => typeof(MagnetFieldFabric);
        
        public override IPlayingFieldService GetService()
        {
            var fabric = PlayingFieldServiceFabricLocator.Instance.GetServiceFabric(CuttingServiceFabricType);
            if (!fabric) return null;

            var implementation = fabric.Create() as MagnetField;
            if (implementation == null) return null;
            
            implementation.Init(force, influenceExclusions);
            return implementation;
        }
    }
}