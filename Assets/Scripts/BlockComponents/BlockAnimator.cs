using System.Collections.Generic;
using System.Linq;
using Animations;
using UnityEngine;

namespace BlockComponents
{
    public class BlockAnimator : MonoBehaviour
    {
        private List<IAnimation> _animations;

        public IEnumerable<IAnimation> Animations => _animations;

        private void Awake()
        {
            _animations = new List<IAnimation>();
        }

        private void Update()
        {
            foreach (var anim in _animations)
            {
                anim.UpdateAnimation(transform, Time.deltaTime);
            }
        }
        
        public void SetAnimations(IEnumerable<IAnimation> animations) => _animations = animations.ToList();
    }
}