using Blocks.BlockComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem
{
    public abstract class CuttingService : MonoBehaviour, ICuttingService
    {
        public abstract void Cut(Block block, Vector2 bladeVector);
    }
}