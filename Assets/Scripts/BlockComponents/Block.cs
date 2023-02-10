using System.Collections.Generic;
using System.Linq;
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
        private CuttingManager _cuttingManager;
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
        public CuttingManager CuttingManager => _cuttingManager;

        private void Awake()
        {
            _cuttingManager = gameObject.AddComponent<CuttingManager>();
            _cuttingManager.Init(this, null);
            
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
            
            _cuttingManager.Clear();
            if (blockSetting.CuttingServicesSettings != null)
            {
                _cuttingManager.Init(this, blockSetting.CuttingServicesSettings.Select(c => c.GetService()));
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
            _cuttingManager.Cut(bladeVector);
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