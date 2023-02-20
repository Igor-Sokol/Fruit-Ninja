using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem
{
    public interface ICutting
    {
        void Cut(Vector2 bladeVector);
    }
}