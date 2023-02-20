using System;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScoreSystem
{
    public class GameScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [FormerlySerializedAs("gameScoreView")] [SerializeField] private TextValue gameTextValueView;
        [FormerlySerializedAs("bestScoreView")] [SerializeField] private TextValue bestTextValueView;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            gameTextValueView.ForceSetValue(scoreManager.CurrentScore);
            bestTextValueView.ForceSetValue(scoreManager.BestScore);
        }

        private void OnEnable()
        {
            scoreManager.GameScoreChanged += gameTextValueView.SetValue;
            scoreManager.BestScoreChanged += bestTextValueView.SetValue;
            scoreManager.ScoreLoaded += Init;
        }

        private void OnDisable()
        {
            scoreManager.GameScoreChanged -= gameTextValueView.SetValue;
            scoreManager.BestScoreChanged -= bestTextValueView.SetValue;
            scoreManager.ScoreLoaded -= Init;
        }
    }
}