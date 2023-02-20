using UnityEngine;

namespace Animations.Factory
{
    public abstract class AnimationFactory : ScriptableObject, IAnimationFactory
    {
        public abstract IAnimation Generate();
    }
}