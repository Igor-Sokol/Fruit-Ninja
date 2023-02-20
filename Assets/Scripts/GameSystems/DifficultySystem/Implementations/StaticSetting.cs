using System;
using UnityEngine;

namespace DifficultySystem.Implementations
{
    [Serializable]
    public struct StaticSetting : IDifficultySetting
    {
        [SerializeField] private int fruitsInPack;
        [SerializeField] private float packInterval;
        [SerializeField] private float fruitInterval;

        public int FruitsInPack => fruitsInPack;
        public float PackInterval => packInterval;
        public float FruitInterval => fruitInterval;

        public StaticSetting(int fruitsInPack, float packInterval, float fruitInterval)
        {
            this.fruitsInPack = fruitsInPack;
            this.packInterval = packInterval;
            this.fruitInterval = fruitInterval;
        }
    }
}