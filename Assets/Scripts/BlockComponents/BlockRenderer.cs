using UnityEngine;

namespace BlockComponents
{
    public class BlockRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private SpriteRenderer shadow;

        public void Renderer(Sprite sprite, bool enableShadow)
        {
            this.sprite.sprite = sprite;
            
            if (enableShadow)
            {
                shadow.sprite = sprite;
                shadow.enabled = true;
            }
            else
            {
                shadow.enabled = false;
            }
        }
    }
}