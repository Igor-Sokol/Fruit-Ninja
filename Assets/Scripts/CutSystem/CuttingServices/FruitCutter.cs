using System.Linq;
using BlockComponents;
using Extensions;
using UnityEngine;

namespace CutSystem.CuttingServices
{
    public class FruitCutter : CuttingService
    {
        [SerializeField] private BlockContainer playingBlockContainer;
        [SerializeField] private BlockContainer brokenPartsContainer;
        [SerializeField] private BlockPool blockPool;
        [SerializeField] private float partsForce;

        public override void Cut(Block block, Vector2 bladeVector)
        {
            var parts = CreateParts(block);

            var normalizedBlade = bladeVector.normalized;
            parts.left.BlockPhysic.AddForce(normalizedBlade.Rotate(-90f), partsForce);
            parts.right.BlockPhysic.AddForce(normalizedBlade.Rotate(90f), partsForce);
        
            playingBlockContainer.RemoveBlock(block);
            blockPool.ReturnBlock(block);
        
            brokenPartsContainer.AddBlock(parts.left);
            brokenPartsContainer.AddBlock(parts.right);
        }

        private (Block left, Block right) CreateParts(Block actualBlock)
        {
            Block[] parts = new Block[2];
            for (int i = 0; i < parts.Length; i++)
            {
                var part = blockPool.GetEmptyBlock();
                part.transform.position = actualBlock.transform.position;
                part.BlockAnimator.SetAnimations(actualBlock.BlockAnimator.Animations.ToArray());

                parts[i] = part;
            }

            var rect = actualBlock.BlockRenderer.Sprite.rect;
            var leftSprite = Sprite.Create(actualBlock.BlockRenderer.Sprite.texture,
                new Rect(rect.x, rect.y, rect.width / 2, rect.height),
                new Vector2(1f, 0.5f));
            var rightSprite = Sprite.Create(actualBlock.BlockRenderer.Sprite.texture,
                new Rect(rect.x + rect.width / 2, rect.y, rect.width / 2, rect.height),
                new Vector2(0f, 0.5f));

            BlockSetting leftSetting = new BlockSetting(leftSprite, actualBlock.BlockPhysic.ColliderRadius,
                actualBlock.BlockRenderer.Shadow.ShadowEnabled);
            BlockSetting rightSetting = new BlockSetting(rightSprite, actualBlock.BlockPhysic.ColliderRadius,
                actualBlock.BlockRenderer.Shadow.ShadowEnabled);
        
            parts[0].SetUp(leftSetting);
            parts[1].SetUp(rightSetting);

            return (parts[0], parts[1]);
        }
    }
}