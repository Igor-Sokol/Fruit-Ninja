using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore;
    private int _bestScore;
    private Coroutine _scoreIncreaseHandler;
    private float _tempScoreValue;

    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField] private float increaseSpeed;

    public int CurrentScore => _currentScore;
    public int BestScore => _bestScore;

    public void AddScore(int score)
    {
        _currentScore += score;
        _bestScore = _currentScore > _bestScore ? _currentScore : _bestScore;
        
        if (_scoreIncreaseHandler == null)
        {
            StartCoroutine(ScoreIncrease());
        }
    }

    public void Clear()
    {
        _tempScoreValue = 0;
        
        _currentScore = 0;
        _bestScore = 0;

        bestScoreText.text = _currentScore.ToString();
        currentScoreText.text = _bestScore.ToString();
    }

    private IEnumerator ScoreIncrease()
    {
        while (_tempScoreValue < _currentScore)
        {
            float step = increaseSpeed * Time.deltaTime;

            _tempScoreValue += step;
            _tempScoreValue = _tempScoreValue > _currentScore ? _currentScore : _tempScoreValue;

            if (_currentScore >= _bestScore)
            {
                bestScoreText.text = ((int)_tempScoreValue).ToString();
            }
            currentScoreText.text = ((int)_tempScoreValue).ToString();

            yield return null;
        }

        _scoreIncreaseHandler = null;
    }
}
