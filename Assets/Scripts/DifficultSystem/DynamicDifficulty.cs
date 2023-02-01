using UnityEngine;
using Random = UnityEngine.Random;

public class DynamicDifficulty : MonoBehaviour
{
    private float _timer;
    private float _secondsToMaxDifficult;
    
    [SerializeField] private Vector2 minutesToMaxDifficultRange;
    [SerializeField] private Vector2 fruitsInPackRange;
    [SerializeField] private Vector2 packIntervalRange;
    [SerializeField] private Vector2 fruitIntervalRange;

    public int FruitsInPack => (int)Mathf.Lerp(fruitsInPackRange.x, fruitsInPackRange.y, _timer / _secondsToMaxDifficult);
    public float PackInterval => Mathf.Lerp(packIntervalRange.x, packIntervalRange.y, _timer / _secondsToMaxDifficult);
    public float FruitInterval => Mathf.Lerp(fruitIntervalRange.x, fruitIntervalRange.y, _timer / _secondsToMaxDifficult);
    
    private void Awake()
    {
        _secondsToMaxDifficult = Random.Range(minutesToMaxDifficultRange.x, minutesToMaxDifficultRange.y) * 60f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }
}
