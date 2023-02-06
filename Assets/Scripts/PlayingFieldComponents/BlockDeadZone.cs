using System;
using System.Collections.Generic;
using BlockComponents;
using UnityEngine;

namespace PlayingFieldComponents
{
    public class BlockDeadZone : MonoBehaviour
    {
        private Rect _actualDeadZone;
    
        [SerializeField] private PlayingField playingField;
        [SerializeField] private BlockPool blockPool;
        [SerializeField] private BlockContainer[] blockContainers;
        [SerializeField] private Rect zone;

        public Rect Zone => zone;

        public event Action<BlockContainer, int> OnBlocksRemoved; 

        private void Start()
        {
            SetUpDeadZone();
        }

        private void Update()
        {
            foreach (var container in blockContainers)
            {
                CheckBeyondZone(container);
            }
        }

        private int CheckBeyondZone(BlockContainer container)
        {
            List<Block> blocksToRemove = null;
            foreach (var block in container.Blocks)
            {
                if (BlockBeyondZone(block.BlockPhysic))
                {
                    if (blocksToRemove == null)
                    {
                        blocksToRemove = new List<Block>();
                    }

                    blocksToRemove.Add(block);
                }
            }
            
            if (blocksToRemove != null)
            {
                DeleteBlock(blocksToRemove, container);
                OnBlocksRemoved?.Invoke(container, blocksToRemove.Count);
                return blocksToRemove.Count;
            }

            return 0;
        }

        private void DeleteBlock(IEnumerable<Block> blocks, BlockContainer container)
        {
            foreach (var block in blocks)
            {
                container.RemoveBlock(block);
                blockPool.ReturnBlock(block);
            }
        }

        private bool BlockBeyondZone(BlockPhysic blockPhysic)
        {
            Vector3 blockPosition = blockPhysic.transform.position;
            var offsetDeadZone = _actualDeadZone;
        
            offsetDeadZone.x += blockPhysic.ColliderRadius;
            offsetDeadZone.y += blockPhysic.ColliderRadius;
            offsetDeadZone.height -= blockPhysic.ColliderRadius;
            offsetDeadZone.width -= blockPhysic.ColliderRadius;
        
            if (blockPosition.x <= offsetDeadZone.x || blockPosition.x >= offsetDeadZone.width 
             || blockPosition.y <= offsetDeadZone.y || blockPosition.y >= offsetDeadZone.height)
            {
                return true;
            }

            return false;
        }

        private void SetUpDeadZone()
        {
            var actualPosition = playingField.PositionFromPercentage(new Vector2(zone.x, zone.y));
            _actualDeadZone.x = actualPosition.x;
            _actualDeadZone.y = actualPosition.y;
        
            actualPosition = playingField.PositionFromPercentage(new Vector2(zone.width, zone.height));
            _actualDeadZone.width = actualPosition.x;
            _actualDeadZone.height = actualPosition.y;
        }
    }
}