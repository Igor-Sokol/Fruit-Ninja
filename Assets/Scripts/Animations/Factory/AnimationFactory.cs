using UnityEngine;

namespace Animations.Fabric
{
    public abstract class AnimationFactory : ScriptableObject, IAnimationFactory
    {
        public abstract IAnimation Generate();
    }
}