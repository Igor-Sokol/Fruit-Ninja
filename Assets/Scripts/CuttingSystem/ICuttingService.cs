using BlockComponents;
using UnityEngine;

namespace CuttingSystem
{
    public interface ICuttingService
    {
        ServiceCallbackAction Cut(Block block, Vector2 bladeVector);
    }
}