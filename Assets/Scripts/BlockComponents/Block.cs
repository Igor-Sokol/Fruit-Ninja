using UnityEngine;

namespace BlockComponents
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockSetting setting;
        [SerializeField] private BlockPhysic blockPhysic;
        [SerializeField] private BlockAnimator blockAnimator;
        [SerializeField] private BlockRenderer blockRenderer;
        [SerializeField] private SpriteRenderer shadow;

        public BlockPhysic BlockPhysic => blockPhysic;
        public BlockAnimator BlockAnimator => blockAnimator;
        public BlockRenderer BlockRenderer => blockRenderer;

        public void SetUp(BlockSetting setting)
        {
            this.setting = setting;
            blockPhysic.SetColliderRadius(this.setting.ColliderRadius);
            blockRenderer.Renderer(setting.Sprite, setting.EnableShadow);
        }
    }
}