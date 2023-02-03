using System.Collections.Generic;
using System.Diagnostics;
using Adaptive;
using UnityEngine;

namespace BlockComponents
{
    public class BlockDeadZone : MonoBehaviour
    {
        private Rect _actualDeadZone;
    
        [SerializeField] private PlayingField playingField;
        [SerializeField] private BlockPool blockPool;
        [SerializeField] private BlockContainer blockContainer;
        [SerializeField] private BlockContainer brokenPartContainer;
        [SerializeField] private Rect zone;

        private void Start()
        {
            var actualPosition = playingField.PositionFromPercentage(new Vector2(zone.x, zone.y));
            _actualDeadZone.x = actualPosition.x;
            _actualDeadZone.y = actualPosition.y;
        
            actualPosition = playingField.PositionFromPercentage(new Vector2(zone.width, zone.height));
            _actualDeadZone.width = actualPosition.x;
            _actualDeadZone.height = actualPosition.y;
        }

        private void Update()
        {
            CheckBeyondZone(blockContainer);
            CheckBeyondZone(brokenPartContainer);
        }

        private void CheckBeyondZone(BlockContainer container)
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
            }
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
    
        [Conditional("UNITY_EDITOR")]
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying) return;
        
            Gizmos.color = Color.red;

            Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(zone.x, zone.y)), 
                playingField.PositionFromPercentage(new Vector2(zone.width, zone.y)));
        
            Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(zone.width, zone.y)),
                playingField.PositionFromPercentage(new Vector2(zone.width, zone.height)));
        
            Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(zone.width, zone.height)),
                playingField.PositionFromPercentage(new Vector2(zone.x, zone.height)));
        
            Gizmos.DrawLine(playingField.PositionFromPercentage(new Vector2(zone.x, zone.height)),
                playingField.PositionFromPercentage(new Vector2(zone.x, zone.y)));
        }
    }
}