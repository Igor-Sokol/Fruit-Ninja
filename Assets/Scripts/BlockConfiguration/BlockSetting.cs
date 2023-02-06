using System;
using System.Collections.Generic;
using CuttingSystem;
using UnityEngine;

namespace BlockConfiguration
{
    [Serializable]
    public struct BlockSetting
    {
        private List<CuttingService> _cuttingService;
        
        [SerializeField] private Sprite sprite;
        [SerializeField] private float colliderRadius;
        [SerializeField] private bool enableShadow;
        [SerializeField] private CuttingServiceType cuttingService;
        [SerializeField] private ParticleSystem cuttingParticle;
        
        public Sprite Sprite => sprite;
        public float ColliderRadius => colliderRadius;
        public bool EnableShadow => enableShadow;
        public ParticleSystem CuttingParticle => cuttingParticle;

        public List<CuttingService> CuttingService => (_cuttingService != null && _cuttingService.Count > 0) 
            ? _cuttingService
            : _cuttingService = CuttingServiceLocator.Instance.GetServices(cuttingService);

        public BlockSetting(Sprite sprite, float colliderRadius, bool enableShadow, 
            List<CuttingService> cuttingService = null, ParticleSystem cuttingParticle = null)
        {
            this.sprite = sprite;
            this.colliderRadius = colliderRadius;
            this.enableShadow = enableShadow;
            this.cuttingService = default;
            this._cuttingService = cuttingService;
            this.cuttingParticle = cuttingParticle;
        }
    }
}