using UnityEngine;

namespace BlockComponents
{
    public class BlockRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Shadow shadow;

        public Shadow Shadow => shadow;

        public Sprite Sprite => sprite.sprite;
        
        public void Renderer(Sprite sprite, bool enableShadow)
        {
            this.sprite.sprite = sprite;
            shadow.SetSprite(sprite);
            shadow.ShadowEnabled = enableShadow;
        }
    }
}