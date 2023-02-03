using System;
using UnityEngine;

namespace BlockComponents
{
    [CreateAssetMenu(fileName = "Block", menuName = "Block")]
    public class BlockSettingObject : ScriptableObject
    {
        [SerializeField] private BlockSetting blockSetting;

        public BlockSetting BlockSetting => blockSetting;
    }
}