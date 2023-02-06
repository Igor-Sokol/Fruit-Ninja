using PlayingFieldComponents;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class BladeMover : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        [SerializeField] private Blade blade;
        [SerializeField] private Camera workingCamera;
    
        public bool Active { get => gameObject.activeSelf; set => gameObject.SetActive(value); }
        
        public void OnDrag(PointerEventData eventData)
        {
            blade.transform.position = (Vector2)workingCamera.ScreenToWorldPoint(eventData.position);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            blade.transform.position = (Vector2)workingCamera.ScreenToWorldPoint(eventData.position);
            blade.ClearTrail();
        }
    }
}
