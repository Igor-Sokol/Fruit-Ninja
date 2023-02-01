using ScriptableObjects;
using UnityEngine;

namespace BlockInteraction
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Block : MonoBehaviour
    {
        private SpriteRenderer _sprite;

        [SerializeField] private BlockSetting setting;
        [SerializeField] private BlockPhysic blockPhysic;
        [SerializeField] private SpriteRenderer shadow;

        public BlockPhysic BlockPhysic => blockPhysic;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void SetUp(BlockSetting setting)
        {
            this.setting = setting;
            _sprite.sprite = this.setting.Sprite;
            blockPhysic.SetColliderRadius(this.setting.ColliderRadius);

            if (setting.EnableShadow)
            {
                shadow.sprite = this.setting.Sprite;
                shadow.enabled = true;
            }
            else
            {
                shadow.enabled = false;
            }
        }
    }
}