using PlayingFieldComponents;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Game
{
    public class BladeMover : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private bool _dragging;
        
        [SerializeField] private Blade blade;
        [SerializeField] private Camera workingCamera;
    
        public bool Active { get => gameObject.activeSelf; set => gameObject.SetActive(value); }

        public void OnBeginDrag(PointerEventData eventData)
        {
            blade.transform.position = (Vector2)workingCamera.ScreenToWorldPoint(eventData.position);
            OnBeginDrag();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_dragging)
            {
                blade.transform.position = (Vector2)workingCamera.ScreenToWorldPoint(eventData.position);
            }
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDrag();
        }

        private void OnBeginDrag()
        {
            blade.ClearTrail();
            blade.enabled = true;
            
            _dragging = true;
        }
        
        public void OnEndDrag()
        {
            _dragging = false;
            blade.enabled = false;
        }
    }
}
