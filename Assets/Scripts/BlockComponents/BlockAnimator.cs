using System.Collections.Generic;
using Animations;
using UnityEngine;

namespace BlockComponents
{
    public class BlockAnimator : MonoBehaviour
    {
        private IAnimation[] _animations;

        public IEnumerable<IAnimation> Animations => _animations;

        private void Update()
        {
            if (_animations != null)
            {
                foreach (var anim in _animations)
                {
                    anim.UpdateAnimation(transform, Time.deltaTime);
                }
            }
        }
        
        public void SetAnimations(IAnimation[] animations) => _animations = animations;
    }
}