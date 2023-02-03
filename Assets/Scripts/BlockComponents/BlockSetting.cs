using System;
using CutSystem;
using UnityEngine;

namespace BlockComponents
{
    [Serializable]
    public struct BlockSetting
    {
        private CuttingService _cuttingService;
        
        [SerializeField] private Sprite sprite;
        [SerializeField] private float colliderRadius;
        [SerializeField] private bool enableShadow;
        [SerializeField] private CuttingServiceType cuttingService;
        [SerializeField] private ParticleSystem cuttingParticle;
        
        public Sprite Sprite => sprite;
        public float ColliderRadius => colliderRadius;
        public bool EnableShadow => enableShadow;
        public ParticleSystem CuttingParticle => cuttingParticle;

        public CuttingService CuttingService => _cuttingService
            ? _cuttingService
            : (_cuttingService = CuttingServiceLocator.Instance.GetService(cuttingService));

        public BlockSetting(Sprite sprite, float colliderRadius, bool enableShadow, 
            CuttingService cuttingService = null, ParticleSystem cuttingParticle = null)
        {
            this.sprite = sprite;
            this.colliderRadius = colliderRadius;
            this.enableShadow = enableShadow;
            this.cuttingService = CuttingServiceType.None;
            this._cuttingService = cuttingService;
            this.cuttingParticle = cuttingParticle;
        }
    }
}