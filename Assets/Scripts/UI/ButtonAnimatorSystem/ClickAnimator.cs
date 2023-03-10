using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.ButtonAnimatorSystem
{
    public class ClickAnimator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Animator animationRenderer;
        [SerializeField] private string onPointerDownAnimation;
        [SerializeField] private string onPointerUpAnimation;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            animationRenderer.Play(onPointerDownAnimation);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            animationRenderer.Play(onPointerUpAnimation);
        }
    }
}