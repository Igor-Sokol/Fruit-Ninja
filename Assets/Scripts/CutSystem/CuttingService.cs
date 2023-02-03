using BlockComponents;
using UnityEngine;

namespace CutSystem
{
    public abstract class CuttingService : MonoBehaviour, ICuttingService
    {
        public abstract void Cut(Block block, Vector2 bladeVector);
    }
}