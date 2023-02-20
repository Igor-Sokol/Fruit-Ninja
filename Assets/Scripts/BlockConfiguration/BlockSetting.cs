using System;
using BeyondZoneSystem;
using CuttingSystem;
using PlayingFieldServices;
using UnityEngine;

namespace BlockConfiguration
{
    [Serializable]
    public struct BlockSetting
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private float colliderRadius;
        [SerializeField] private bool enableShadow;
        [SerializeField] private CuttingServiceProvider[] cuttingServices;
        [SerializeField] private BeyondServiceProvider[] beyondServiceSettings;
        [SerializeField] private PlayingFieldServiceSetting[] playingFieldServiceSettings;

        public Sprite Sprite => sprite;
        public float ColliderRadius => colliderRadius;
        public bool EnableShadow => enableShadow;
        public CuttingServiceProvider[] CuttingServicesSettings => cuttingServices;
        public BeyondServiceProvider[] BeyondServiceSettings => beyondServiceSettings;
        public PlayingFieldServiceSetting[] PlayingFieldServiceSettings => playingFieldServiceSettings;

        public BlockSetting(Sprite sprite, float colliderRadius, bool enableShadow,
            CuttingServiceProvider[] cuttingServices = null, BeyondServiceProvider[] beyondServiceSettings = null,
            PlayingFieldServiceSetting[] playingFieldServiceSettings = null)
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