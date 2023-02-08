using System.Collections.Generic;
using BeyondZoneSystem;
using BlockConfiguration;
using CuttingSystem;
using Managers;
using UnityEngine;

namespace BlockComponents
{
    public class Block : MonoBehaviour, ICutting, IBeyondService
    {
        private BlockSetting _blockSetting;
        private List<ICuttingService> _cuttingService;
        private List<IBeyondService> _beyondServices;

        [SerializeField] private BlockSettingObject settingObject;
        [SerializeField] private BlockPhysic blockPhysic;
        [SerializeField] private BlockAnimator blockAnimator;
        [SerializeField] private BlockRenderer blockRenderer;
        [SerializeField] private TimeScaleManager timeScaleManager;

        public BlockSetting BlockSetting => _blockSetting;
        public BlockPhysic BlockPhysic => blockPhysic;
        public BlockAnimator BlockAnimator => blockAnimator;
        public BlockRenderer BlockRenderer => blockRenderer;

        private void Awake()
        {
            _cuttingService = new List<ICuttingService>();
            _beyondServices = new List<IBeyondService>();
            SetTimeScaleManager(timeScaleManager);
        }

        public void SetTimeScaleManager(TimeScaleManager scaleManager)
        {
            timeScaleManager = scaleManager;
            BlockAnimator.SetTimeScaleManager(scaleManager);
            blockPhysic.SetTimeScaleManager(scaleManager);
        }
        
        public void SetUp(BlockSettingObject settingObject)
        {
            this.settingObject = settingObject;
            SetUp(this.settingObject.BlockSetting);
        } 
        
        public void SetUp(BlockSetting blockSetting)
        {
            _blockSetting = blockSetting;
            blockPhysic.SetColliderRadius(blockSetting.ColliderRadius);
            blockRenderer.Renderer(blockSetting.Sprite, blockSetting.EnableShadow);

            _cuttingService.Clear();
            if (blockSetting.CuttingServicesSettings != null)
            {
                foreach (var cuttingServiceSetting in blockSetting.CuttingServicesSettings)
                {
                    _cuttingService.Add(cuttingServiceSetting.GetService());
                }
            }
            
            _beyondServices.Clear();
            if (blockSetting.BeyondServiceSettings != null)
            {
                foreach (var serviceSetting in blockSetting.BeyondServiceSettings)
                {
                    _beyondServices.Add(serviceSetting.GetService());
                }
            }
        }

        public void Cut(Vector2 bladeVector)
        {
            foreach (var service in _cuttingService)
            {
                service.Cut(this, bladeVector);
            }
        }

        public void BeyondZoneAction()
        {
            foreach (var service in _beyondServices)
            {
                service.BeyondZoneAction();
            }
        }
    }
}