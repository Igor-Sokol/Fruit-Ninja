using System;
using UnityEngine;

namespace ScoreSystem
{
    public class GameScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Score gameScoreView;
        [SerializeField] private Score bestScoreView;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            gameScoreView.ForceSetValue(scoreManager.CurrentScore);
            bestScoreView.ForceSetValue(scoreManager.BestScore);
        }

        private void OnEnable()
        {
            scoreManager.GameScoreChanged += gameScoreView.SetValue;
            scoreManager.BestScoreChanged += bestScoreView.SetValue;
            scoreManager.ScoreLoaded += Init;
        }

        private void OnDisable()
        {
            scoreManager.GameScoreChanged -= gameScoreView.SetValue;
            scoreManager.BestScoreChanged -= bestScoreView.SetValue;
            scoreManager.ScoreLoaded -= Init;
        }
    }
}