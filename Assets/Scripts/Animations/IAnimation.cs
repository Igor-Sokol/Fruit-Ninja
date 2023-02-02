using UnityEngine;

namespace Animations
{
    public interface IAnimation
    {
        void UpdateAnimation(Transform transform, float deltaTime);
    }
}