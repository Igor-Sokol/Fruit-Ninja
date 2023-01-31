using UnityEngine;

namespace Adaptive
{
    public class FullscreenSprite : MonoBehaviour
    {
        void Awake()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            transform.position = Vector2.zero;

            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

            Vector2 scale = Vector2.one;
            float horizontal = ScreenManager.Instance.CameraSize.x / spriteSize.x;
            float vertical = ScreenManager.Instance.CameraSize.y / spriteSize.y;

            scale *= horizontal >= vertical ? horizontal : vertical;
            transform.localScale = scale;
        }
    }
}