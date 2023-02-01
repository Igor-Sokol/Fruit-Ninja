using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Block", menuName = "Block", order = 1)]
    public class BlockSetting : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private float colliderRadius;
        [SerializeField] private bool enableShadow;

        public Sprite Sprite => sprite;

        public float ColliderRadius => colliderRadius;

        public bool EnableShadow => enableShadow;
    }
}