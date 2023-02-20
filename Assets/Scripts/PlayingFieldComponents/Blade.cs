using System.Collections.Generic;
using Blocks.BlockServices.CuttingSystem;
using UnityEngine;

namespace PlayingFieldComponents
{
    public class Blade : MonoBehaviour
    {
        [SerializeField] private TrailRenderer trailRenderer;
        [SerializeField] private BlockContainer playingBlockContainer;
        [SerializeField] private float bladeLength;

        private void Update()
        {
            CheckBlocks();
        }
    
        private void CheckBlocks()
        {
            if (trailRenderer.positionCount > 1)
            {
                Vector3[] trailPositions = new Vector3[trailRenderer.positionCount];
                trailRenderer.GetPositions(trailPositions);
            
                var actualPosition = trailPositions[trailPositions.Length - 1];
                var bladeVector = actualPosition - trailPositions[trailPositions.Length - 2];

                if (bladeVector.magnitude <= bladeLength) return;

                List<ICutting> blocksToCut = null;
                foreach (var block in playingBlockContainer.Blocks)
                {
                    if ((block.transform.position - actualPosition).magnitude <= block.BlockPhysic.ColliderRadius)
                    {
                        if (blocksToCut == null)
                        {
                            blocksToCut = new List<ICutting>();
                        }
                    
                        blocksToCut.Add(block);
                    }
                }

                if (blocksToCut != null)
                {
                    foreach (var blockToRemove in blocksToCut)
                    {
                        blockToRemove.Cut(bladeVector);
                    }
                }
            }
        }

        public void ClearTrail()
        {
            trailRenderer.Clear();
        }
    }
}
