using UnityEngine;

namespace Adaptive
{
    public class FullscreenSprite : MonoBehaviour
    {
        [SerializeField] private PlayingField playingField;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        void Awake()
        {
            transform.position = Vector2.zero;

            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

            Vector2 scale = Vector2.one;
            float horizontal = playingField.FieldSize.x / spriteSize.x;
            float vertical = playingField.FieldSize.y / spriteSize.y;

            scale *= horizontal >= vertical ? horizontal : vertical;
            transform.localScale = scale;
        }
    }
}