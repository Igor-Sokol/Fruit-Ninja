using BlockComponents;
using UnityEngine;

namespace CuttingSystem
{
    public interface ICuttingService
    {
        void Cut(Block block, Vector2 bladeVector);
    }
}