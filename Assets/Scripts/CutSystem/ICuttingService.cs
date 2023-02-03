using BlockComponents;
using UnityEngine;

namespace CutSystem
{
    public interface ICuttingService
    {
        void Cut(Block block, Vector2 bladeVector);
    }
}