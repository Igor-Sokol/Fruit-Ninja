using System.Linq;
using Blocks.BlockComponents;
using Blocks.BlockConfiguration;
using Blocks.BlockStackSystem;
using Extensions.Vectors;
using PlayingFieldComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Implementations
{
    public class PartsCutter : ICuttingService
    {
        private readonly BlockContainer _playingBlockContainer;
        private readonly BlockStackGenerator _blockStackGenerator;
        private float _partsForce;

        public void Init(float partsForce)
        {
            _partsForce = partsForce;
        }

        public PartsCutter(BlockContainer playingBlockContainer, BlockStackGenerator blockStackGenerator)
        {
            _playingBlockContainer = playingBlockContainer;
            _blockStackGenerator = blockStackGenerator;
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

            _playingBlockContainer.AddBlock(leftPart);
            _playingBlockContainer.AddBlock(rightPart);
        }

        private Block CreatePart(Block block, Rect textureRect, Vector2 texturePivot)
        {
            var part = _blockStackGenerator.GetEmptyBlock();
            part.transform.position = block.transform.position;
            part.transform.localScale = block.transform.localScale;
            part.BlockAnimator.SetAnimations(block.BlockAnimator.Animations.ToArray());
            
            var sprite = Sprite.Create(block.BlockRenderer.Sprite.texture, textureRect, texturePivot, block.BlockRenderer.Sprite.pixelsPerUnit);

            BlockSetting leftSetting = new BlockSetting(sprite, block.BlockPhysic.ColliderRadius,
                block.BlockRenderer.Shadow.ShadowEnabled);

            part.SetUp(leftSetting);

            return part;
        }
    }
}