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
        [SerializeField] private CuttingServiceSetting[] cuttingServices;
        [SerializeField] private BeyondServiceSetting[] beyondServiceSettings;
        [SerializeField] private PlayingFieldServiceSetting[] playingFieldServiceSettings;

        public Sprite Sprite => sprite;
        public float ColliderRadius => colliderRadius;
        public bool EnableShadow => enableShadow;
        public CuttingServiceSetting[] CuttingServicesSettings => cuttingServices;
        public BeyondServiceSetting[] BeyondServiceSettings => beyondServiceSettings;
        public PlayingFieldServiceSetting[] PlayingFieldServiceSettings => playingFieldServiceSettings;

        public BlockSetting(Sprite sprite, float colliderRadius, bool enableShadow,
            CuttingServiceSetting[] cuttingServices = null, BeyondServiceSetting[] beyondServiceSettings = null,
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