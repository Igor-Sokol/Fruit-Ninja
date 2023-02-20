using System.Collections.Generic;
using System.Linq;
using Animations;
using Managers;
using UnityEngine;

namespace BlockComponents
{
    public class BlockAnimator : MonoBehaviour
    {
        private List<IAnimation> _animations;

        [SerializeField] private TimeScaleManager timeScaleManager;
        
        public IEnumerable<IAnimation> Animations => _animations;

        public void SetTimeScaleManager(TimeScaleManager scaleManager)
        {
            timeScaleManager = scaleManager;
        }
        
        private void Awake()
        {
            _animations = new List<IAnimation>();
        }

        private void Update()
        {
            float timeScale = timeScaleManager ? timeScaleManager.CurrentScale : Time.timeScale;
            
            foreach (var anim in _animations)
            {
                anim.UpdateAnimation(transform, Time.deltaTime * timeScale);
            }
        }
        
        public void SetAnimations(IEnumerable<IAnimation> animations) => _animations = animations.ToList();
    }
}