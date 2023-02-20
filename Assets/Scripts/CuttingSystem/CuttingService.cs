using BlockComponents;
using UnityEngine;

namespace CuttingSystem
{
    public abstract class CuttingService : MonoBehaviour, ICuttingService
    {
        public abstract void Cut(Block block, Vector2 bladeVector);
    }
}