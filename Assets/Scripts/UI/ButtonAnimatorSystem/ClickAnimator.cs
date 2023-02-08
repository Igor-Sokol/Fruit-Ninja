using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UI.ButtonAnimatorSystem
{
    public class ClickAnimator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Animation animationRenderer;
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