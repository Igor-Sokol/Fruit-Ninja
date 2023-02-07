using System;
using BlockConfiguration;
using UnityEngine;

namespace PlayingFieldComponents
{
    [Serializable]
    public struct BlockStackSetting
    {
        [SerializeField][Range(0f,1f)] private float maximumAllowable;
        [SerializeField] private float priority;
        [SerializeField] private BlockSettingObject[] blocks;

        public float MaximumAmountPercentage => maximumAllowable;
        public float Priority => priority;
        public BlockSettingObject[] Blocks => blocks;
    }
}