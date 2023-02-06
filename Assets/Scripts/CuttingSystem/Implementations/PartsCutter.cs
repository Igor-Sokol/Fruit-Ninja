using System.Linq;
using BlockComponents;
using BlockConfiguration;
using Extensions;
using PlayingFieldComponents;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class PartsCutter : ICuttingService
    {
        private readonly BlockContainer _playingBlockContainer;
        private readonly BlockPool _blockPool;
        private float _partsForce;

        public void Init(float partsForce)
        {
            _partsForce = partsForce;
        }

        public PartsCutter(BlockContainer playingBlockContainer, BlockPool blockPool)
        {
            _playingBlockContainer = playingBlockContainer;
            _blockPool = blockPool;
        }

        public void Cut(Block block, Vector2 bladeVector)
        {
            var currentSpriteRect = block.BlockRenderer.Sprite.rect;
            
            var leftPart = CreatePart(block,
                new Rect(currentSpriteRect.x, currentSpriteRect.y, currentSpriteRect.width / 2, currentSpriteRect.height),
                new Vector2(1f, 0.5f));
            var rightPart = CreatePart(block,
                new Rect(currentSpriteRect.x + currentSpriteRect.width / 2, currentSpriteRect.y, currentSpriteRect.width / 2, currentSpriteRect.height),
                new Vector2(0f, 0.5f));

            var normalizedBlade = bladeVector.normalized;
            leftPart.BlockPhysic.SetForce(normalizedBlade.Rotate(-90f) + (Vector2)block.BlockPhysic.Velocity.normalized,
                _partsForce);
            rightPart.BlockPhysic.SetForce(normalizedBlade.Rotate(90f) + (Vector2)block.BlockPhysic.Velocity.normalized,
                _partsForce);
        
            _playingBlockContainer.RemoveBlock(block);
            _blockPool.ReturnBlock(block);
        
            _playingBlockContainer.AddBlock(leftPart);
            _playingBlockContainer.AddBlock(rightPart);
        }

        private Block CreatePart(Block block, Rect textureRect, Vector2 texturePivot)
        {
            var part = _blockPool.GetEmptyBlock();
            part.transform.position = block.transform.position;
            part.transform.localScale = block.transform.localScale;
            part.BlockAnimator.SetAnimations(block.BlockAnimator.Animations.ToArray());
            
            var sprite = Sprite.Create(block.BlockRenderer.Sprite.texture, textureRect, texturePivot);

            BlockSetting leftSetting = new BlockSetting(sprite, block.BlockPhysic.ColliderRadius,
                block.BlockRenderer.Shadow.ShadowEnabled);

            part.SetUp(leftSetting);

            return part;
        }
    }
}