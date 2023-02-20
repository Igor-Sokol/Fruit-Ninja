using Blocks.BlockComponents;
using UI.Game;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Implementations
{
    public class BladeInterrupt : ICuttingService
    {
        private readonly BladeMover _bladeMover;

        public BladeInterrupt(BladeMover bladeMover)
        {
            _bladeMover = bladeMover;
        }
        
        public void Cut(Block block, Vector2 bladeVector)
        {
            _bladeMover.OnEndDrag();
        }
    }
}