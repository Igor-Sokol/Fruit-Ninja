using BlockComponents;
using UnityEngine;

namespace CutSystem.CuttingServices
{
    public class BlotParticle : CuttingService
    {
        public override void Cut(Block block, Vector2 bladeVector)
        {
            var blotParticle = Instantiate(block.BlockSetting.CuttingParticle, block.transform.position, Quaternion.identity);
            blotParticle.transform.localScale = block.transform.localScale;
        }
    }
}