using UnityEngine;

namespace ScoreSystem
{
    public class GameScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Score gameScoreView;
        [SerializeField] private Score bestScoreView;

        private void OnEnable()
        {
            scoreManager.GameScoreChanged += gameScoreView.SetValue;
            scoreManager.BestScoreChanged += bestScoreView.SetValue;
        }

        private void OnDisable()
        {
            scoreManager.GameScoreChanged -= gameScoreView.SetValue;
            scoreManager.BestScoreChanged -= bestScoreView.SetValue;
        }
    }
}