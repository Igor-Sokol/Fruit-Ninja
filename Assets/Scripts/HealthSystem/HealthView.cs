using System.Collections;
using System.Collections.Generic;
using PlayingFieldComponents;
using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    [RequireComponent(typeof(RectTransform))]
    public class HealthView : MonoBehaviour
    {
        private List<Heart> _hearts;
        private int _healthOnBar;
        private Vector2? _customSpawnPosition;

        [SerializeField] private HealthService healthService;
        [SerializeField] private ObjectPool<Heart> heartPool;
        [SerializeField] private Transform container;
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private float heartMoveTime;
            
        private void Start()
        {
            _hearts = new List<Heart>(healthService.MaxHealth);
            
            AddHeart(healthService.StartHealth);
        }

        public void Clear()
        {
            _customSpawnPosition = null;
            foreach (var heart in _hearts)
            {
                heartPool.Return(heart);
            }
            
            AddHeart(healthService.StartHealth);
        }

        private void AddHeart(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var heart = heartPool.Get();
                _hearts.Add(heart);
                heart.Appear();



                StartCoroutine(MoveHeartToPosition(heart, GetSpawnPosition(), GetNextGridPosition()));
                _healthOnBar++;
            }
        }
        
        private void RemoveHeart(int count)
        {
            for (int i = 0; i < count && _hearts.Count > 0; i++)
            {
                var heart = _hearts[_hearts.Count - 1];
                _hearts.RemoveAt(_hearts.Count - 1);

                heart.OnDisappeared += ReturnHeart;
                heart.Disappear();
                _healthOnBar--;
            }
        }

        public void SetSpawnPosition(Vector2 wordPosition)
        {
            _customSpawnPosition = wordPosition;
        }
        
        private Vector2 GetSpawnPosition()
        {
            if (_customSpawnPosition.HasValue) return _customSpawnPosition.Value;

            return GetNextGridPosition();
        }
        
        private Vector2 GetNextGridPosition()
        {
            int elementId = _healthOnBar;

            Vector2 position = gridLayoutGroup.transform.localPosition;
            position -= new Vector2(gridLayoutGroup.cellSize.x / 2, gridLayoutGroup.cellSize.y / 2);
            
            position -= new Vector2(elementId % gridLayoutGroup.constraintCount * (gridLayoutGroup.spacing.x + gridLayoutGroup.cellSize.x), 0);
            position -= new Vector2(0, elementId / gridLayoutGroup.constraintCount * (gridLayoutGroup.spacing.y + gridLayoutGroup.cellSize.y));

            return gridLayoutGroup.transform.TransformVector(position);
        }

        private void ReturnHeart(Heart heart)
        {
            heart.OnDisappeared -= ReturnHeart;
            heartPool.Return(heart);
        }
        
        private void OnEnable()
        {
            healthService.HealthIncreased += AddHeart;
            healthService.HealthDecreased += RemoveHeart;
        }

        private void OnDisable()
        {
            healthService.HealthIncreased -= AddHeart;
            healthService.HealthDecreased -= RemoveHeart;
        }

        private IEnumerator MoveHeartToPosition(Heart heart, Vector2 startPosition, Vector2 targetPosition)
        {
            float timer = 0;
            
            while (timer < heartMoveTime)
            {
                timer += Time.deltaTime;
                
                heart.transform.position = Vector2.Lerp(startPosition, targetPosition, timer / heartMoveTime);

                yield return null;
            }
            
            heart.transform.SetParent(container);
        }
    }
}