using System.Linq;
using BlockComponents;
using Extensions;
using UnityEngine;

namespace CutSystem.CuttingServices
{
    public class PartsCutter : CuttingService
    {
        [SerializeField] private BlockContainer playingBlockContainer;
        [SerializeField] private BlockContainer brokenPartsContainer;
        [SerializeField] private BlockPool blockPool;
        [SerializeField] private float partsForce;

        public override void Cut(Block block, Vector2 bladeVector)
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
                partsForce);
            rightPart.BlockPhysic.SetForce(normalizedBlade.Rotate(90f) + (Vector2)block.BlockPhysic.Velocity.normalized,
                partsForce);
        
            playingBlockContainer.RemoveBlock(block);
            blockPool.ReturnBlock(block);
        
            brokenPartsContainer.AddBlock(leftPart);
            brokenPartsContainer.AddBlock(rightPart);
        }

        private Block CreatePart(Block block, Rect textureRect, Vector2 texturePivot)
        {
            var part = blockPool.GetEmptyBlock();
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