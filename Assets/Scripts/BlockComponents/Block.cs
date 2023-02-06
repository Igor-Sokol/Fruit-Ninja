using System.Collections.Generic;
using BlockConfiguration;
using CuttingSystem;
using UnityEngine;

namespace BlockComponents
{
    public class Block : MonoBehaviour, ICutting
    {
        private BlockSetting _blockSetting;
        private List<CuttingService> _cuttingService;
        
        [SerializeField] private BlockSettingObject settingObject;
        [SerializeField] private BlockPhysic blockPhysic;
        [SerializeField] private BlockAnimator blockAnimator;
        [SerializeField] private BlockRenderer blockRenderer;

        public BlockSetting BlockSetting => _blockSetting;
        public BlockPhysic BlockPhysic => blockPhysic;
        public BlockAnimator BlockAnimator => blockAnimator;
        public BlockRenderer BlockRenderer => blockRenderer;

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
            _cuttingService = blockSetting.CuttingService;
        }

        public void Cut(Vector2 bladeVector)
        {
            foreach (var service in _cuttingService)
            {
                service.Cut(this, bladeVector);
            }
        }
    }
}