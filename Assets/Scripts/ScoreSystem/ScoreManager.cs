using System;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreManager : MonoBehaviour
    {
        private int _currentScore;
        private int _bestScore;

        public int CurrentScore => _currentScore;
        public int BestScore => _bestScore;
        public event Action<int> GameScoreChanged;
        public event Action<int> BestScoreChanged;

        public void AddScore(int score)
        {
            _currentScore += score;
            GameScoreChanged?.Invoke(_currentScore);

            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;
                BestScoreChanged?.Invoke(_bestScore);
            }
        }

        public void Clear()
        {
            _currentScore = 0;
            ReadBestScore();
        }

        private void ReadBestScore()
        {
            _bestScore = 0;
        }
    }
}
