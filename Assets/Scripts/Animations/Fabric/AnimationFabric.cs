using UnityEngine;

namespace Animations.Fabric
{
    public abstract class AnimationFabric : ScriptableObject, IAnimationFabric
    {
        public abstract IAnimation Generate();
    }
}