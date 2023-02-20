using System.Linq;
using UnityEngine;

namespace GameSystems.DifficultySystem.Implementations
{
    public class DynamicDifficulty : DifficultySetting
    {
        private float _timer;
        private float _secondsToMaxDifficult;
    
        [SerializeField] private Vector2 fruitsInPackRange;
        [SerializeField] private Vector2 packIntervalRange;
        [SerializeField] private Vector2 fruitIntervalRange;
        [SerializeField] private DifficultyPoint[] difficultGraph;
    
        public override int FruitsInPack => (int)Mathf.Lerp(fruitsInPackRange.x, fruitsInPackRange.y, GetDifficultyPercentage());
        public override float PackInterval => Mathf.Lerp(packIntervalRange.x, packIntervalRange.y, GetDifficultyPercentage());
        public override float FruitInterval => Mathf.Lerp(fruitIntervalRange.x, fruitIntervalRange.y, GetDifficultyPercentage());

        private void Awake()
        {
            difficultGraph = difficultGraph.OrderBy(d => d.Minute).ToArray();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public void Clear()
        {
            _timer = 0;
        }
        
        private float GetDifficultyPercentage()
        {
            var minute = _timer / 60;

            DifficultyPoint previous = default;
            foreach (var point in difficultGraph)
            {
                if (minute < point.Minute)
                {
                    return Mathf.Lerp(previous.DifficultyPercentage, point.DifficultyPercentage,
                        Mathf.InverseLerp(previous.Minute, point.Minute, minute));
                }

                previous = point;
            }

            return 1;
        }
    }
}