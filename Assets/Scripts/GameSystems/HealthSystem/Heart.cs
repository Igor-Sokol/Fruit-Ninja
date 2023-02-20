using System;
using UnityEngine;

namespace GameSystems.HealthSystem
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private Animation animationRender;
        [SerializeField] private string appearanceAnimation;
        [SerializeField] private string disappearanceAnimation;

        public event Action<Heart> OnDisappeared;

        public void Appear()
        {
            gameObject.SetActive(true);
            animationRender.Play(appearanceAnimation);
        }
        
        public void Disappear()
        {
            animationRender.Play(disappearanceAnimation);
        }
        
        private void HeartDisableCallback()
        {
            gameObject.SetActive(false);
            OnDisappeared?.Invoke(this);
        }
    }
}
