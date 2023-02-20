using System;
using BlockConfiguration;
using BlockStackSystem.Restrictions;
using UnityEngine;
using UnityEngine.Serialization;

namespace BlockStackSystem
{
    [Serializable]
    public struct BlockStackSetting
    {
        [SerializeField][Range(0f,1f)] private float maxAllowablePercentage;
        [SerializeField] private float maxAllowable;
        [SerializeField] private float priority;
        [SerializeField] private BlockSettingObject[] blocks;
        [SerializeField] private Restriction[] restrictions;

        public float MaxAmountPercentage => maxAllowablePercentage;
        public float MaxAllowable => maxAllowable;
        public float Priority => priority;
        public BlockSettingObject[] Blocks => blocks;
        public Restriction[] Restrictions => restrictions;
    }
}