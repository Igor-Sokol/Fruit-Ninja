using UnityEngine;

namespace HealthSystem
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private Animation animationRender;
        [SerializeField] private string appearanceAnimation;
        [SerializeField] private string disappearanceAnimation;

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
        }
    }
}
