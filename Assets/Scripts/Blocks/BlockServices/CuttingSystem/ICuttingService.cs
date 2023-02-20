using Blocks.BlockComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem
{
    public interface ICuttingService
    {
        void Cut(Block block, Vector2 bladeVector);
    }
}