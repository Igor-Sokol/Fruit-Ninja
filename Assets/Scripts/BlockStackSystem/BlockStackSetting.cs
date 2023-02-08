using System;
using BlockConfiguration;
using BlockStackSystem.Restrictions;
using UnityEngine;

namespace BlockStackSystem
{
    [Serializable]
    public struct BlockStackSetting
    {
        [SerializeField][Range(0f,1f)] private float maximumAllowable;
        [SerializeField] private float priority;
        [SerializeField] private BlockSettingObject[] blocks;
        [SerializeField] private Restriction[] restrictions;

        public float MaximumAmountPercentage => maximumAllowable;
        public float Priority => priority;
        public BlockSettingObject[] Blocks => blocks;
        public Restriction[] Restrictions => restrictions;
    }
}