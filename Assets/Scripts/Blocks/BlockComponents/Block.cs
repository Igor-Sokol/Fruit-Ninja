using System.Collections.Generic;
using System.Linq;
using Blocks.BlockConfiguration;
using Blocks.BlockServices.BeyondZoneSystem;
using Blocks.BlockServices.CuttingSystem;
using Blocks.BlockServices.PlayingFieldServices;
using Managers;
using UnityEngine;

namespace Blocks.BlockComponents
{
    public class Block : MonoBehaviour, ICutting, IBeyondService, IOnPlayingField
    {
        private BlockSetting _blockSetting;
        private CuttingManager _cuttingManager;
        private List<IBeyondService> _beyondServices;
        private PlayingFieldServiceManager _playingFieldServiceManager;

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
        public List<IBeyondService> BeyondServices => _beyondServices;
        public PlayingFieldServiceManager PlayingFieldServiceManager => _playingFieldServiceManager;

        private void Awake()
        {
            _cuttingManager = gameObject.AddComponent<CuttingManager>();
            _cuttingManager.Init(this, null);
            
            _beyondServices = new List<IBeyondService>();
            
            _playingFieldServiceManager = gameObject.AddComponent<PlayingFieldServiceManager>();
            _cuttingManager.Init(this, null);

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
            
            _playingFieldServiceManager.Clear();
            if (blockSetting.PlayingFieldServiceSettings != null)
            {
                _playingFieldServiceManager.Init(this, blockSetting.PlayingFieldServiceSettings.Select(c => c.GetService()));
            }
        }

        public void Cut(Vector2 bladeVector)
        {
            _cuttingManager.Cut(bladeVector);
        }

        public void BeyondZoneAction(Block block)
        {
            foreach (var service in _beyondServices)
            {
                service.BeyondZoneAction(this);
            }
        }

        public void OnPlayingField()
        {
            _playingFieldServiceManager.OnPlayingField();
        }
    }
}