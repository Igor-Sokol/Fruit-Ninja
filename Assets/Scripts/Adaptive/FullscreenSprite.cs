using UnityEngine;

namespace Adaptive
{
    public class FullscreenSprite : MonoBehaviour
    {
        [SerializeField] private PlayingField playingField;
        
        void Awake()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

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