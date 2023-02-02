using Animations;
using UnityEngine;

namespace BlockComponents
{
    public class BlockAnimator : MonoBehaviour
    {
        private IAnimation[] _animations;

        private void Update()
        {
            foreach (var anim in _animations)
            {
                anim.UpdateAnimation(transform, Time.deltaTime);
            }
        }
        
        public void SetAnimations(IAnimation[] animations) => _animations = animations;
    }
}