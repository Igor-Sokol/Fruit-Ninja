using System;
using Blocks.BlockServices.BeyondZoneSystem;
using Blocks.BlockServices.CuttingSystem;
using Blocks.BlockServices.PlayingFieldServices;
using UnityEngine;

namespace Blocks.BlockConfiguration
{
    [Serializable]
    public struct BlockSetting
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private float colliderRadius;
        [SerializeField] private bool enableShadow;
        [SerializeField] private CuttingServiceFactory[] cuttingServices;
        [SerializeField] private BeyondServiceFactory[] beyondServiceSettings;
        [SerializeField] private PlayingFieldServiceFactory[] playingFieldServiceSettings;

        public Sprite Sprite => sprite;
        public float ColliderRadius => colliderRadius;
        public bool EnableShadow => enableShadow;
        public CuttingServiceFactory[] CuttingServicesSettings => cuttingServices;
        public BeyondServiceFactory[] BeyondServiceSettings => beyondServiceSettings;
        public PlayingFieldServiceFactory[] PlayingFieldServiceSettings => playingFieldServiceSettings;

        public BlockSetting(Sprite sprite, float colliderRadius, bool enableShadow,
            CuttingServiceFactory[] cuttingServices = null, BeyondServiceFactory[] beyondServiceSettings = null,
            PlayingFieldServiceFactory[] playingFieldServiceSettings = null)
        {
            this.sprite = sprite;
            this.colliderRadius = colliderRadius;
            this.enableShadow = enableShadow;
            this.cuttingServices = cuttingServices;
            this.beyondServiceSettings = beyondServiceSettings;
            this.playingFieldServiceSettings = playingFieldServiceSettings;
        }
    }
}